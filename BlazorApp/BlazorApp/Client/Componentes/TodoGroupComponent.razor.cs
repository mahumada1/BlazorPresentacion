using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace BlazorApp.Client.Componentes
{
    partial class TodoGroupComponent
    {
        [Parameter]
        public TodoGroup ItemGrupo { get; set; }

        //public TelerikAnimationContainer? AnimationContainer { get; set; }
        public bool AgregarNuevoRegistro { get; set; } = false;

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        [Parameter]
        public EventCallback<TodoItemsUpdateInfoArgs> OnTodoItemsUpdateInfo { get; set; }

        public void AgregarRegistro()
        {
            AgregarNuevoRegistro = true;
        }

        public async void ConfirmarTarea()
        {
            var item = new TodoItem
            {
                ItemGroupId = this.ItemGrupo.Id,
                Titulo = this.Titulo
            };

            ItemGrupo.Items?.Add(item);

            var total = ItemGrupo.Items?.Count;
            var pendientes = ItemGrupo.Items?.Count(a => a.Pendiente == true);
            await OnTodoItemsUpdateInfo.InvokeAsync(new TodoItemsUpdateInfoArgs { Total = total, Pendientes = pendientes });

            this.Titulo = string.Empty;
        }

        public void Toggle()
        {
            AgregarNuevoRegistro ^= true;
            //if (AnimationContainer != null)
            //    await AnimationContainer.ToggleAsync();
        }

    }

    public class TodoItemsUpdateInfoArgs : EventArgs
    {
        public int? Total { get; set; }
        public int? Pendientes { get; set; }
    }
}
