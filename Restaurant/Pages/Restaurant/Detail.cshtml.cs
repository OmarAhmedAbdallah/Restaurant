using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Core;
using Restuarant.Data;

namespace OmarRestaurant.Pages.Restaurant
{
    public class DetailModel : PageModel
    {
        private readonly IRestuarantData restuarantData;

        public MainRestaurant restaurant { get; set; }

        public DetailModel(IRestuarantData restuarantData)
        {
            this.restuarantData = restuarantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restuarantData.GetRestuarantSearchById(restaurantId);

            if (restaurant == null)
                return RedirectToPage("NotFound");
            return Page();
        }
    }
}