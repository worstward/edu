﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Controllers
{
    [Helpers.Exception]
    public class GalleryController : Controller
    {
        //
        // GET: /Gallery/
        public ActionResult ViewGallery()
        {
            return View();
        }
	}
}