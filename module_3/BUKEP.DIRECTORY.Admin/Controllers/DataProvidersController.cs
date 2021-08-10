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
        private readonly IAttributeService _attributeService;

        public DataProvidersController(IDataProviderService providerService, IAttributeService attributeService)
        {
            _providerService = providerService;
            _attributeService = attributeService;
        }

        // GET: DataProvidersController
        public ActionResult Index()
        {
            var providers = _providerService.Get();
            var providersView = providers.Select(i => new DataProviderViewModel
            {
                Id = i.Id,
                Name = i.Name,
                DataSourceAttributes = i.DataSourceAttributes.Select(x => new AttributeViewModel { Id = x.Id, Name = x.Name, Description = x.Description }).ToList(),
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

        // GET: DataProvidersController/AddAttribute/1/1
        public ActionResult AddAttribute(AttributeType attributeType, int providerId)
        {
            ViewBag.ProviderId = providerId;
            ViewBag.AttributeType = attributeType;

            var attributes = _attributeService.Get();
            var provider = _providerService.Get(providerId);

            var availableAttributes = new List<Attribute>();

            switch (attributeType)
            {
                case AttributeType.DataSource:
                    availableAttributes = attributes.Where(i => !provider.DataSourceAttributes.Select(x => x.Id).Contains(i.Id)).ToList();
                    break;
                case AttributeType.Field:
                    availableAttributes = attributes.Where(i => !provider.FieldAttributes.Select(x => x.Id).Contains(i.Id)).ToList();
                    break;
            }

            return View(availableAttributes.Select(i => new AttributeViewModel { Id = i.Id, Name = i.Name, Description = i.Description}));
        }


        // POST: DataProvidersController/AddAttribute
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAttribute(AttributeType attributeType, int providerId, int attributeId)
        {
            try
            {
                switch (attributeType)
                {
                    case AttributeType.DataSource:
                        _providerService.AddSourceAttribute(providerId, attributeId);
                        break;
                    case AttributeType.Field:
                        _providerService.AddFieldAttribute(providerId, attributeId);
                        break;
                }
                return RedirectToAction(nameof(AddAttribute), new { attributeType, providerId });
            }
            catch
            {
                return View();
            }
        }
    }
}
