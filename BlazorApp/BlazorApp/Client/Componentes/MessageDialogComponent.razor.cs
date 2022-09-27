using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Telerik.Blazor;

namespace BlazorApp.Client.Componentes
{
    partial class MessageDialogComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public MessageDialog Context { get; set; }
    }
}