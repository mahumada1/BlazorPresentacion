using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class TodoGroup
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public List<TodoItem>? Items { get; set; }
        public int? Total => Items?.Count(a=> a.Activo);
        public int? Pendientes => Items?.Count(p=> p.Pendiente == true && p.Activo);
        
    }
}
