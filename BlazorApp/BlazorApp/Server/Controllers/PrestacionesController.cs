using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proactive.Domain;
using proactive.DTO;
using proactive.Global;

namespace BlazorApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrestacionesController : ControllerBase
    {
        private static readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
        public PrestacionesController()
        {
            if (string.IsNullOrEmpty(Cfg.connString))
                Cfg.connString = config.GetConnectionString("DefaultConn");
        }

        [HttpGet]
        public async Task<Process<List<Prestacion>>> GetPrestaciones()
        {
            var result = await Task.Run(() => OrdenDomain.PrestacionObtenerTodas());
            if (result.Result ==(int) Result.success)
            {
                var areas = OrdenDomain.AreaObtenerTodas().Data;
                var especialidades = OrdenDomain.EspecialidadObtenerTodas().Data;
                foreach(var prt in result.Data)
                {
                    prt.Area = areas.FirstOrDefault(a => a.Id == prt.AreaId);
                    prt.Especialidad = especialidades.FirstOrDefault(e => e.Id == prt.EspecialidadId);
                }
            }
            Thread.Sleep(3000);
            return result;
        }
    }
}
