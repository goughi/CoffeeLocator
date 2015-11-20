using System.Collections.Generic;
using CoffeeApp.Models;

namespace CoffeeApp.ViewModels
{
    public class CoffeeIndexData

    {

        public IEnumerable<CoffeeStore> CoffeeStores { get; set; }
        public IEnumerable<Drink> Drinks { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
