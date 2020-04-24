using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Restaurant.Core;
using Restuarant.Data;

namespace OmarRestaurant.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestuarantData restuarantData;

        public string message { get; set; }
        public IEnumerable<MainRestaurant> Restaurants { get; set; }



        //this atrr can read from query string 
        //this atrr use data bind by asp-for in cshtml  
        //(SupportsGet = true) is must
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                         IRestuarantData restuarantData)
        {
            this.config = config;
            this.restuarantData = restuarantData;
        }
        public void OnGet()
        {
            message = config["Message"];
            Restaurants = restuarantData.GetRestuarantSearchByName(SearchTerm);
        }
    }
}
