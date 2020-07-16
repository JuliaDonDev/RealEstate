using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Models.ViewModels;
using RealEstate.Providers.Interfaces;

namespace RealEstate.Controllers
{
    public class ZillowDataController : Controller
    {
        private IZillowDataProvider provider;

        public ZillowDataController(IZillowDataProvider provider)
        {
            this.provider = provider;
        }
        public ViewResult Location() => View(new Location());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Location(Location locationModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(SoldEstate), new {city = locationModel.City, state = locationModel.State});
            }
            ModelState.AddModelError("", "Wrong data. Please, reenter city and state.");
            return View(locationModel);
        }

        public ViewResult SoldEstate(string city, string state) => View(new SoldEstateViewModel()
        {
            SoldEstates = provider?.GetSoldRealEstateData(city, state) ?? new List<SoldEstate>()
        });
    }
}
