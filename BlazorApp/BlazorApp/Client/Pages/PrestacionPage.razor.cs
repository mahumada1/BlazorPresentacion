using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using proactive.Core;
using proactive.DTO;
using System.Net.Http.Json;
using Telerik.Blazor;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Pages
{
    partial class PrestacionPage
    {
        public int ValorRadio { get; set; } = 1;
        public List<Prestacion> ListadoPrestaciones { get; set; } = new List<Prestacion>();
        public bool CargandoPrestaciones { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            var resultPrts = await Http.GetFromJsonAsync<Process<List<Prestacion>>>("Prestaciones");
            this.ListadoPrestaciones = new List<Prestacion>();
            if(resultPrts.Result == (int)Result.success)
            {
                ListadoPrestaciones = resultPrts.Data;
                CargandoPrestaciones = false;
            }
        }

        

    }
}
