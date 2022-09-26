using Microsoft.AspNetCore.Components;
using proactive.DTO;

namespace BlazorApp.Client.Componentes
{
    partial class PrestacionTelerik
    {
        [Parameter]
        public List<Prestacion> ListadoPrestaciones { get; set; } = new List<Prestacion>();

        public List<int?> PageSizes { get; set; } = new List<int?> { 5, 10, 20, null };
        int CurrentPage = 1;
        int PageSize = 10;

    }
}
