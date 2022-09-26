using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int ItemGroupId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Pendiente { get; set; }
        public bool Activo { get; set; }
    }
}
