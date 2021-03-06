using BUKEP.DIRECTORY.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY.Admin.Controllers
{
    public class DataSourcesController : Controller
    {
        private readonly IDataSourceService _sourceService;
        private readonly IDataProviderService _providerService;

        public DataSourcesController(IDataSourceService sourceService, IDataProviderService providerService)
        {
            _sourceService = sourceService;
            _providerService = providerService;
        }

        // GET: DataSourcesController
        public ActionResult Index()
        {
            var dataSources = _sourceService.Get();
            var model = dataSources.Select(i => new DataSourceViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description
            });

            return View(model);
        }

        // GET: DataSourcesController/Attributes/5
        public ActionResult Attributes(int sourceId)
        {
            var source = _sourceService.Get(sourceId);
            var provider = _providerService.Get(source.ProviderId);

            var models = provider.SourceAttributes.Select(i => new AttributeViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                Value = source.Attributes.FirstOrDefault(a => a.Id == i.Id)?.Value
            }).ToList();

            ViewBag.SourceId = source.Id;
            ViewBag.ProviderId = provider.Id;
            return View(models);
        }

        // POST: DataSourcesController/Attributes
        [HttpPost]
        public ActionResult Attributes(int sourceId, int providerId, IEnumerable<AttributeViewModel> models)
        {
            try
            {
                foreach (var item in models)
                {
                    _sourceService.SaveSourceAttribute(item.Id, sourceId, providerId, item.Value ?? string.Empty);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: DataSourcesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataSourcesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DataSourceViewModel model)
        {
            try
            {
                var dataSource = new DataSource
                {
                    Name = model.Name,
                    Description = model.Description,
                    ProviderId = model.ProviderId
                };

                _sourceService.Add(dataSource);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DataSourcesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DataSourcesController/Edit/5
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

        // GET: DataSourcesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DataSourcesController/Delete/5
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
