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
        private readonly IServiceEmailSendGrid _serviceEmail;

        public HomeController(ILogger<HomeController> logger,
            IRepositoryProject repositoryProject,
            IConfiguration configuration,
            IServiceEmailSendGrid serviceEmail
            
            )
        {
            _logger = logger;
            _repositoryProject = repositoryProject;
            _configuration = configuration;
            _serviceEmail = serviceEmail;
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
        [HttpGet]

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel contact)
        {
            await _serviceEmail.Send(contact);
            return RedirectToAction("Thanks");
        }
        public IActionResult Thanks()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}