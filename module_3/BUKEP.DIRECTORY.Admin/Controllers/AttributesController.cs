using BUKEP.DIRECTORY.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BUKEP.DIRECTORY.Admin.Controllers
{
    public class AttributesController : Controller
    {
        private readonly IAttributeService _attributeService;

        public AttributesController(IAttributeService attributeService)
        {
            _attributeService = attributeService;
        }


        // GET: AttributesController
        public ActionResult Index()
        {
            var attributes = _attributeService.Get();
            var model = attributes.Select(i => new AttributeViewModel { Id = i.Id, Name = i.Name, Description = i.Description });

            return View(model);
        }

        // GET: AttributesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AttributesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttributesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttributeViewModel attribute)
        {
            try
            {
                _attributeService.Add(new Attribute { Name = attribute.Name, Description = attribute.Description });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AttributesController/Edit/5
        public ActionResult Edit(int id)
        {
            var attribute = _attributeService.Get(id);
            var model = new AttributeViewModel
            {
                Id = attribute.Id,
                Name = attribute.Name,
                Description = attribute.Description
            };

            return View(model);
        }

        // POST: AttributesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AttributeViewModel attribute)
        {
            try
            {
                _attributeService.Update(new Attribute { 
                    Id = id,
                    Name = attribute.Name,
                    Description = attribute.Description
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Edit", id);
            }
        }

        // GET: AttributesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AttributesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
