﻿using BUKEP.DIRECTORY.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUKEP.DIRECTORY.Admin.Controllers
{
    public class DataSourcesController : Controller
    {
        private readonly IDataSourceService _dataSourceService;

        public DataSourcesController(IDataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;
        }

        // GET: DataSourcesController
        public ActionResult Index()
        {
            var dataSources = _dataSourceService.Get();
            var model = dataSources.Select(i => new DataSourceViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description
            });

            return View(model);
        }

        // GET: DataSourcesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                _dataSourceService.Add(dataSource);

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
