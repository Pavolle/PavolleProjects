﻿using Microsoft.AspNetCore.Mvc;

namespace Pavolle.BES.GeoServer.Service.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}