// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcSampleApp.ViewData;
using MvcSampleApp.Models;

namespace MvcSampleApp.Controllers
{
    public class ProductController : Controller
    {
        private IAdventureWorksRepository repository;

        public ProductController()
        {
            this.repository = new AdventureWorksRepository();
        }

        public ProductController(IAdventureWorksRepository repository)
        {
            this.repository = repository;
        }

        //
        // GET: /Product/

        public ActionResult Index(int? page)
        {
            var viewData = new ProductViewData();
            int currentPage = page ?? 0;
            viewData.Products = this.repository.GetProducts(currentPage, 10);
            viewData.NextPage = currentPage + 1;
            viewData.PreviousPage = (currentPage <= 0) ? 0 : currentPage - 1;
            return View(viewData);
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            var product = this.repository.GetProductById(id);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        //
        // POST: /Product/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Product product = new Product();
                UpdateModel(product);
                this.repository.AddProduct(product);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }

        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id)
        {
            Product product = new Product();
            product = this.repository.GetProductById(id);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Product product = new Product();
                product = this.repository.GetProductById(id);
                UpdateModel(product);
                this.repository.UpdateProduct();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}