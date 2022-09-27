using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using Telerik.Blazor;
using Telerik.Blazor.Components;

namespace BlazorApp.Client.Componentes
{
    partial class TodoGroupComponent
    {
        [Parameter]
        public TodoGroup ItemGrupo { get; set; }
        [Parameter]
        public EventCallback<TodoItemsUpdateInfoArgs> OnTodoItemsUpdateInfo { get; set; }


        public TelerikAnimationContainer? AnimationContainer { get; set; }
        public bool AgregarNuevoRegistro { get; set; } = false;
        public bool VerTareasEliminadas { get; set; } = false;

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; } = DateTime.Now;

        public MessageDialog MessageContext { get; set; } = new MessageDialog();

        

        public void AgregarRegistro()
        {
            AgregarNuevoRegistro = true;
        }

        public async void ConfirmarTarea()
        {
            var item = new TodoItem
            {
                ItemGroupId = this.ItemGrupo.Id,
                Titulo = this.Titulo,
                Descripcion = this.Descripcion,
                FechaVencimiento = this.FechaVencimiento,
                Activo = true, 
                Pendiente = true,
                Id = this.ItemGrupo.Items == null ? 0 : this.ItemGrupo.Items.Count,
            };

            ItemGrupo.Items?.Add(item);

            ActualizarInformacion();
            Toggle();

        }

        public async void Toggle()
        {
            AgregarNuevoRegistro ^= true;

            this.Titulo = string.Empty;
            this.Descripcion = String.Empty;
            this.FechaVencimiento = DateTime.Now;

            if (AnimationContainer != null)
                await AnimationContainer.ToggleAsync();
        }

        public void CompletarTarea(int idTarea)
        {
            var item = ItemGrupo.Items?.FirstOrDefault(t => t.Id == idTarea);
            if(item != null)
            {
                item.Pendiente = false;
            }
            ActualizarInformacion();
        }

        public void ReactivarTarea(int idTarea)
        {
            var item = ItemGrupo.Items?.FirstOrDefault(t => t.Id == idTarea);
            if (item != null)
            {
                item.Pendiente = true;
                item.Activo = true;
            }
            ActualizarInformacion();
        }

        public void EliminarTarea(int idTarea)
        {
            var cerrarAction = new Action(() =>
            {
                MessageContext.Visible = false;
            });

            var removerAction = new Action(() =>
            {
                var item = ItemGrupo.Items?.FirstOrDefault(t => t.Id == idTarea);
                if (item != null)
                {
                    item.Activo = false;
                }
                MessageContext.Visible = false;
                ActualizarInformacion();
            });

            MessageContext = new MessageDialog
            {
                Visible = true,
                Titulo = "Valtek",
                Icon = "gears",
                MostrarCloseButton = true,
                Width = "350px",
                Mensaje = "¿Esta seguro que desea eliminar la tarea?",
                ListadoBotones = new List<MessageButtons>
                {
                   new MessageButtons{ ColorBoton = ThemeConstants.Button.ThemeColor.Success, TituloBoton = "OK", EventoBoton = (() => { removerAction();}) },
                   new MessageButtons{ ColorBoton = ThemeConstants.Button.ThemeColor.Error, TituloBoton = "Cancelar", EventoBoton = (() => { cerrarAction();}) },
                }
            };


        }

        public async void ActualizarInformacion()
        {
            var total = ItemGrupo.Items?.Count;
            var pendientes = ItemGrupo.Items?.Count(a => a.Pendiente == true);
            await OnTodoItemsUpdateInfo.InvokeAsync(new TodoItemsUpdateInfoArgs { Total = total, Pendientes = pendientes });
        }

    }

    public class TodoItemsUpdateInfoArgs : EventArgs
    {
        public int? Total { get; set; }
        public int? Pendientes { get; set; }
    }
}
