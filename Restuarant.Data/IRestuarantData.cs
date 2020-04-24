using Restaurant.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Restuarant.Data
{
    public interface IRestuarantData
    {
        IEnumerable<MainRestaurant> GetAll();
        IEnumerable<MainRestaurant> GetRestuarantSearchByName(string name);
        MainRestaurant GetRestuarantSearchById(int id);
    }

    public class InMemoryRestuarantData : IRestuarantData
    {
        readonly List<MainRestaurant> restaurants;

        public InMemoryRestuarantData()
        {
            restaurants = new List<MainRestaurant>()
                {
                    new MainRestaurant {Id = 1 , Name = "Italian", Location="Rome",Cuisine = CuisineType.Italian},
                    new MainRestaurant {Id = 2 , Name = "Indian", Location="India",Cuisine = CuisineType.Indian},
                    new MainRestaurant {Id = 3 , Name = "Mexican", Location="Mexico",Cuisine = CuisineType.Mexican},
                    new MainRestaurant {Id = 4 , Name = "Egyptian", Location="Egypt",Cuisine = CuisineType.None},
                };
        }
        public IEnumerable<MainRestaurant> GetAll() => restaurants
                                                    .OrderBy(r => r.Name)
                                                    .Select(r => r);

        public MainRestaurant GetRestuarantSearchById(int id) => restaurants
                                                              .SingleOrDefault(r => r.Id == id);

        public IEnumerable<MainRestaurant> GetRestuarantSearchByName(string name = null) 
            => restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).OrderBy(r => r.Name).Select(r => r);


    }
}
