using BUKEP.DIRECTORY.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUKEP.DIRECTORY.Admin.Controllers
{
    public class DataProvidersController : Controller
    {
        private readonly IDataProviderService _providerService;

        public DataProvidersController(IDataProviderService providerService)
        {
            _providerService = providerService;
        }

        // GET: DataProvidersController
        public ActionResult Index()
        {
            var providers = _providerService.GetProviders();
            var providersView = providers.Select(i => new DataProviderViewModel
            {
                Id = i.Id,
                Name = i.Name,
                DataSourceAttributes = i.DataSourceAttributes.Select(x => new AttributeViewModel { Id = x.Id, Name = x.Name, Description = x.Description}).ToList(),
                FieldAttributes = i.FieldAttributes.Select(x => new AttributeViewModel { Id = x.Id, Name = x.Name, Description = x.Description }).ToList(),
            });

            return View(providersView);
        }

        // GET: DataProvidersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DataProvidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataProvidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DataProviderViewModel provider)
        {
            try
            {
                var result = _providerService.Add(provider.Name);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DataProvidersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DataProvidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: DataProvidersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DataProvidersController/Delete/5
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

        // GET: DataProvidersController/AddAttribute/1
        public ActionResult AddSourceAttribute(int providerId)
        {
            var provider = _providerService.GetProvider(providerId);

            return View(providerId);
        }

        // POST: DataProvidersController/AddAttribute
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSourceAttribute(int providerId, int attributeId)
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
