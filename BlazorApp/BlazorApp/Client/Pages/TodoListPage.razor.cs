using BlazorApp.Client.Componentes;
using BlazorApp.Shared;

namespace BlazorApp.Client.Pages
{
    partial class TodoListPage
    {
        public List<TodoGroup> ListadoGrupos{ get; set; } = new List<TodoGroup>();

        protected override async Task OnInitializedAsync()
        {
            ListadoGrupos = new List<TodoGroup>{
                new TodoGroup { Id = 1, Nombre = "Pendientes Desarrollo", Activo = true, Descripcion = "tareas pendientes del área de Desarrollo", 
                    Items = new List<TodoItem> {
                                                    new TodoItem { Id = 11, Activo = true, Titulo = "11 Ingreso ordenes", Descripcion = "Tarea Pendiente 11", FechaVencimiento = DateTime.Now, Pendiente = true }, 
                                                    new TodoItem { Id = 12, Activo = true, Titulo = "12 Ingreso ordenes", Descripcion = "Tarea Pendiente 12", FechaVencimiento = DateTime.Now, Pendiente = true }, 
                                                    new TodoItem { Id = 13, Activo = true, Titulo = "13 Ingreso ordenes", Descripcion = "Tarea Pendiente 13", FechaVencimiento = DateTime.Now, Pendiente = false }, 
                                                    new TodoItem { Id = 14, Activo = true, Titulo = "14 Ingreso ordenes", Descripcion = "Tarea Pendiente 14", FechaVencimiento = DateTime.Now, Pendiente = true }, 
                                                }    
                            },
                new TodoGroup { Id = 2, Nombre = "Pendientes Soporte", Activo = false, Descripcion = "tareas pendientes del área de Soporte",
                    Items = new List<TodoItem> {
                                                    new TodoItem { Id = 21, Activo = true, Titulo = "21 Analizadores", Descripcion = "Tarea Pendiente 21", FechaVencimiento = DateTime.Now, Pendiente = true },
                                                    new TodoItem { Id = 22, Activo = true, Titulo = "22 Impresora", Descripcion = "Tarea Pendiente 22", FechaVencimiento = DateTime.Now, Pendiente = true },
                                                }
                            },
                new TodoGroup { Id = 3, Nombre = "Pendientes Implementación", Activo = true, Descripcion = "tareas pendientes del área de Implementación",
                    Items = new List<TodoItem> {
                                                    new TodoItem { Id = 31, Activo = true, Titulo = "31 Cliente", Descripcion = "Tarea Pendiente 31", FechaVencimiento = DateTime.Now, Pendiente = false },
                                                    new TodoItem { Id = 32, Activo = true, Titulo = "32 Cliente", Descripcion = "Tarea Pendiente 32", FechaVencimiento = DateTime.Now, Pendiente = true },
                                                }
                },
            };
        }

        public void ActualizarItems(TodoItemsUpdateInfoArgs info)
        {
            StateHasChanged();
        }

        public void RemoveTodoGroup(int id)
        {

        }
        
        public void ItemResize()
        {
            StateHasChanged();
        }
    }
}
