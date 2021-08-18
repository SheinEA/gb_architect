using BUKEP.DIRECTORY.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace BUKEP.DIRECTORY.Admin.Controllers
{
    public class DirectoryController : Controller
    {
        private readonly IDirectoryService _directoryService;
        private readonly ILogger<DirectoryController> _logger;

        public DirectoryController(ILogger<DirectoryController> logger, IDirectoryService directoryService)
        {
            _logger = logger;
            _directoryService = directoryService;
        }

        public IActionResult Index()
        {
            var directories = _directoryService.Get();

            var models = directories.Select(i => new DirectoryViewModel
            {
                Id = i.Id,
                SourceId = i.Source.Id,
                AccessObjectId = i.AccessObjectId,
                Title = i.Title,
                SourceName = i.Source.Name
            });

            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: DirectoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DirectoryViewModel model)
        {
            try
            {
                _directoryService.Add(model.Title, model.SourceId, model.AccessObjectId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
