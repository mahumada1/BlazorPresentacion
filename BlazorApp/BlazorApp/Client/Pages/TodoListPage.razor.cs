using BlazorApp.Client.Componentes;
using BlazorApp.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;

namespace BlazorApp.Client.Pages
{
    partial class TodoListPage
    {
        [Inject]
        public ILocalStorageService localStorageService{ get; set; }

        public List<TodoGroup> ListadoGrupos{ get; set; } = new List<TodoGroup>();

        public MessageDialog MessageContext{ get; set; } = new MessageDialog();
        public string NombreGrupo { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                var items = await localStorageService.ContainKeyAsync("TodoList") ? await localStorageService.GetItemAsync<List<TodoGroup>>("TodoList") : null;
                if (items != null)
                {
                    ListadoGrupos = items;
                    StateHasChanged();
                }
            }
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    ListadoGrupos = new List<TodoGroup>{
        //        new TodoGroup { Id = 1, Nombre = "Pendientes Desarrollo", Activo = true, Descripcion = "tareas pendientes del área de Desarrollo", 
        //            Items = new List<TodoItem> {
        //                                            new TodoItem { Id = 11, Activo = true, Titulo = "11 Ingreso ordenes", Descripcion = "Tarea Pendiente 11", FechaVencimiento = DateTime.Now, Pendiente = true }, 
        //                                            new TodoItem { Id = 12, Activo = true, Titulo = "12 Ingreso ordenes", Descripcion = "Tarea Pendiente 12", FechaVencimiento = DateTime.Now, Pendiente = true }, 
        //                                            new TodoItem { Id = 13, Activo = true, Titulo = "13 Ingreso ordenes", Descripcion = "Tarea Pendiente 13", FechaVencimiento = DateTime.Now, Pendiente = false }, 
        //                                            new TodoItem { Id = 14, Activo = true, Titulo = "14 Ingreso ordenes", Descripcion = "Tarea Pendiente 14", FechaVencimiento = DateTime.Now, Pendiente = true }, 
        //                                        }    
        //                    },
        //        new TodoGroup { Id = 2, Nombre = "Pendientes Soporte", Activo = false, Descripcion = "tareas pendientes del área de Soporte",
        //            Items = new List<TodoItem> {
        //                                            new TodoItem { Id = 21, Activo = true, Titulo = "21 Analizadores", Descripcion = "Tarea Pendiente 21", FechaVencimiento = DateTime.Now, Pendiente = true },
        //                                            new TodoItem { Id = 22, Activo = true, Titulo = "22 Impresora", Descripcion = "Tarea Pendiente 22", FechaVencimiento = DateTime.Now, Pendiente = true },
        //                                        }
        //                    },
        //        new TodoGroup { Id = 3, Nombre = "Pendientes Implementación", Activo = true, Descripcion = "tareas pendientes del área de Implementación",
        //            Items = new List<TodoItem> {
        //                                            new TodoItem { Id = 31, Activo = true, Titulo = "31 Cliente", Descripcion = "Tarea Pendiente 31", FechaVencimiento = DateTime.Now, Pendiente = false },
        //                                            new TodoItem { Id = 32, Activo = true, Titulo = "32 Cliente", Descripcion = "Tarea Pendiente 32", FechaVencimiento = DateTime.Now, Pendiente = true },
        //                                        }
        //        },
        //    };
        //}

        public async void ActualizarItems(TodoItemsUpdateInfoArgs info)
        {
            await localStorageService.SetItemAsync("TodoList", ListadoGrupos);
            StateHasChanged();
        }

        public async void RecuperarRegistros()
        {
            foreach(var grupo in ListadoGrupos)
            {
                grupo.Activo = true;
                if(grupo.Items != null)
                {
                    foreach (var tarea in grupo.Items)
                    {
                        tarea.Activo = true;
                        tarea.Pendiente = true;
                    }
                }
            }
            await localStorageService.SetItemAsync("TodoList", ListadoGrupos);
            StateHasChanged();
        }

        public async void AgregarGrupo()
        {
            this.ListadoGrupos.Add(new TodoGroup
            {
                Activo = true,
                Nombre = NombreGrupo,
                Id = ListadoGrupos.Count,
                Descripcion = NombreGrupo,
                Items = new List<TodoItem>()
            });
            this.NombreGrupo = String.Empty;
            await localStorageService.SetItemAsync("TodoList", ListadoGrupos);
            StateHasChanged();
        }

        public void RemoveTodoGroup(int id)
        {
            var cerrarAction = new Action(() => 
            {
                MessageContext.Visible = false;
            });

            var removerAction = new Action(async () =>
            {
                var grupo = ListadoGrupos.FirstOrDefault(g => g.Id == id);
                if (grupo != null)
                    grupo.Activo = false;
                MessageContext.Visible = false;
                await localStorageService.SetItemAsync("TodoList", ListadoGrupos);
                StateHasChanged();
            });

            MessageContext = new MessageDialog
            {
                Visible = true,
                Titulo = "Valtek",
                Icon = "gears",
                MostrarCloseButton = true,
                Width = "350px",
                Mensaje = "¿Esta seguro que desea eliminar el Grupo?",
                ListadoBotones = new List<MessageButtons>
                {
                   new MessageButtons{ ColorBoton = ThemeConstants.Button.ThemeColor.Success, TituloBoton = "OK", EventoBoton = (() => { removerAction();}) },
                   new MessageButtons{ ColorBoton = ThemeConstants.Button.ThemeColor.Error, TituloBoton = "Cancelar", EventoBoton = (() => { cerrarAction();}) },
                }
            };

        }
        
        public void ItemResize()
        {
            StateHasChanged();
        }
    }
}
