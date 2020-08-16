using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KudVenkatEmploymentPortal.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace KudVenkatEmploymentPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Home/Error/{request}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int request)
        {
            var errorResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            var exceptionResult = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ErrorViewModel errorViewModel = null;
            switch (request)
            {
                case 404:
                     errorViewModel = new ErrorViewModel
                    {
                        RequestId = errorResult.OriginalPath,
                        Message = "Requested resource not available"

                    };
                    _logger.LogError($"Page not found for the  requested path: {errorResult.OriginalPath}");
            break;
                default:
                    errorViewModel = new ErrorViewModel
                    {
                        RequestId = exceptionResult.Path,
                        Message = "Default"

                    };
                    _logger.LogError($"{exceptionResult.Error} and requested path: {exceptionResult.Path}");
                    break;

            }
            return View(errorViewModel);
        }
    }
}
