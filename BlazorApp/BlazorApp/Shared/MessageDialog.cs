using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class MessageDialog
    {
        public bool Visible { get; set; }
        public string Icon { get; set; }
        public bool MostrarCloseButton { get; set; } = true;
        public string Titulo { get; set; } = "Valtek";
        public string Mensaje { get; set; }
        public string Width { get; set; } = "600px";
        public List<MessageButtons> ListadoBotones { get; set; } = new List<MessageButtons>();
    }

    public class MessageButtons
    {
        public string TituloBoton { get; set; }
        public string ColorBoton { get; set; }
        public Action EventoBoton { get; set; }
    }
}
