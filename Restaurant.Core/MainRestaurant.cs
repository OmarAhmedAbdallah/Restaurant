using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Core
{
    public partial class MainRestaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
