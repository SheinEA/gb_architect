﻿using BUKEP.DIRECTORY.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUKEP.DIRECTORY.Admin.Controllers
{
    public class FieldsController : Controller
    {
        private readonly IFieldService _fieldService;

        public FieldsController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        // GET: FieldsController
        public ActionResult Index(int sourceId)
        {
            var fields = _fieldService.GetBySourceId(sourceId);
            var model = fields.Select(i => new FieldViewModel
            {
                Id = i.Id,
                Name = i.Name,
                DataSourceId = i.DataSourceId,
                DataType = i.DataType
            });

            ViewBag.SourceId = sourceId;

            return View(model);
        }

        // GET: FieldsController/Attributes/5
        public ActionResult Attributes(int sourceId)
        {
            //var source = _dataSourceService.Get(sourceId);
            //var provider = _dataProviderService.Get(source.ProviderId);

            //var models = provider.DataSourceAttributes.Select(i => new AttributeViewModel
            //{
            //    Id = i.Id,
            //    Name = i.Name,
            //    Description = i.Description,
            //    Value = source.Attributes.FirstOrDefault(a => a.Id == i.Id)?.Value
            //}).ToList();

            //ViewBag.SourceId = source.Id;
            //ViewBag.ProviderId = provider.Id;
            return View(/*models*/);
        }

        // POST: FieldsController/Attributes
        [HttpPost]
        public ActionResult Attributes(int sourceId, int providerId, IEnumerable<AttributeViewModel> models)
        {
            try
            {
                foreach (var item in models)
                {
                    //_dataSourceService.SaveSourceAttribute(item.Id, sourceId, providerId, item.Value);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: FieldsController/Create
        public ActionResult Create(int sourceId)
        {
            ViewBag.SourceId = sourceId;
            return View();
        }

        // POST: FieldsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FieldViewModel model)
        {
            try
            {
                var field = new Field
                {
                    Name = model.Name,
                    DataSourceId = model.DataSourceId,
                    DataType = model.DataType
                };

                _fieldService.Add(field);

                return RedirectToAction(nameof(Index), new { sourceId = model.DataSourceId });
            }
            catch
            {
                return View();
            }
        }

        // GET: FieldsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FieldsController/Edit/5
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

        // GET: FieldsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FieldsController/Delete/5
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
