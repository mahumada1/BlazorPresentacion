using Microsoft.AspNetCore.Components;
using proactive.DTO;

namespace BlazorApp.Client.Componentes
{
    partial class PrestacionHtml
    {
        [Parameter]
        public List<Prestacion> ListadoPrestaciones { get; set; } = new List<Prestacion>();
    }
}
