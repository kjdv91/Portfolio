using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryProject _repositoryProject;
        private readonly IConfiguration _configuration; //info appsettings

        public HomeController(ILogger<HomeController> logger,
            IRepositoryProject repositoryProject,
            IConfiguration configuration
            
            )
        {
            _logger = logger;
            _repositoryProject = repositoryProject;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var apellido = _configuration.GetValue<string>("Apellido");//info proveedor de configuracion
            _logger.LogInformation("Mensaje de log" + apellido);
        
            var projects = _repositoryProject.GetProject().Take(2).ToList();  //solo obtengo los 2 primeros proyectos
            var model = new HomeIndexViewModel()
            {
                Projects = projects
            };
           

            return View(model);
        }

       
       public IActionResult Projects()
        {
            var projects = _repositoryProject.GetProject();
            return View(projects);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}