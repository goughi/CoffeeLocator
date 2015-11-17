using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace CoffeeApp.Models
{
    public enum Rating { 1, 2, 3, 4, 5 }
    public enum DrinkSize { tall, grande, vendi }
    public class CoffeeStore
    {
        public String StoreName { get; set; }
        [Key]
        public String Eircode { get; set; }

        public String Location { get; set; }
        public bool IsOpen { get; set; }
        [Range(0,5,ErrorMessage ="rating must be between 1 and 5")]
        public double StoreRating { get; set; }

        public virtual ICollection<Drink> Drinks { get; set; }
    }
    public class Drink
    {
        [Key]
        public int DrinkID { get; set; }
        public String DrinkName { get; set; }
        public DrinkSize DrinkSize { get; set; }
        public double Price { get; set; }

        public String Eircode { get; set; }
        public virtual CoffeeStore CoffeeStore { get; set; }

    }

    public class DrinkContext : DbContext
    {
        public DrinkContext() : base("DefaultConnection")
        {
            Database.SetInitializer<DrinkContext>(new DropCreateDatabaseIfModelChanges<DrinkContext>());
        }
        public DbSet<CoffeeStore> CoffeeStores { get; set; }
        public DbSet<Drink> Drinks { get; set; }
    }

    public class DrinkRepository
    {
        public void AddStore(CoffeeStore cs)
        {
            using (DrinkContext db = new DrinkContext())
            {
                try
                {
                    db.CoffeeStores.Add(cs);
                    db.SaveChanges();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }

       static void AddStore(Drink drink)
        {
            using (DrinkContext db = new DrinkContext())
            {
                try
                {
                    db.Drinks.Add(drink);
                    db.SaveChanges();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }
    }
    public class CodeFirstTest
    {
        static void main()
        {
            DrinkRepository repository = new DrinkRepository();
            CoffeeStore st1 = new CoffeeStore() { Eircode = "C15C98E", Location = "O' Connell St. Limerick", IsOpen = true, StoreName = "Starbucks", StoreRating = 0 };
            repository.AddStore(st1);
        }
    }
}