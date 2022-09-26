using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using proactive.DTO;

namespace BlazorApp.Client.Componentes
{
	partial class PrestacionHtmlVirtual
	{
        [Parameter]
        public List<Prestacion> ListadoPrestaciones { get; set; } = new List<Prestacion>();

        private async ValueTask<ItemsProviderResult<Prestacion>> CargarPrestaciones(ItemsProviderRequest request)
        {
            await Task.Delay(100);
            var prestacionesToTake = Math.Min(request.Count, ListadoPrestaciones.Count - request.StartIndex);
            var prestacionesToShow = ListadoPrestaciones.Skip(request.StartIndex).Take(prestacionesToTake);
            return new ItemsProviderResult<Prestacion>(prestacionesToShow, ListadoPrestaciones.Count);
        }
    }


}
