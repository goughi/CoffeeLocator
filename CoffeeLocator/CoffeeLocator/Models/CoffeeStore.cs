using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;//needed to add these in
using System.Data.Entity;//enitity framework

namespace CoffeeApp.Models
{
    public enum DrinkSize { tall, grande, large }

    //the store location
    public class CoffeeStore
    {
        public String StoreName { get; set; }
        [Key]
        public String Eircode { get; set; }

        public String Location { get; set; }
        public bool IsOpen { get; set; }
        [Range(0, 5, ErrorMessage = "rating must be between 1 and 5")]
        public double StoreRating { get; set; }

        public virtual ICollection<Drink> Drinks { get; set; }
    }

    //drinks
    public class Drink
    {
        [Key]
        public int DrinkID { get; set; }
        public String DrinkName { get; set; }
        public bool IsHot { get; set; }
        public DrinkSize DrinkSize { get; set; }
        public double Price { get; set; }
        public double DrinkRating { get; set; }

        public String Eircode { get; set; }
        public virtual CoffeeStore CoffeeStore { get; set; }

    }
    //collections of drinks in data
    public class DrinkContext : DbContext
    {
        public DrinkContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<DrinkContext>(new DropCreateDatabaseIfModelChanges<DrinkContext>());
        }
        public DbSet<CoffeeStore> CoffeeStores { get; set; }
        public DbSet<Drink> Drinks { get; set; }
    }




    //should a repos
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
        static void AddStore(Drink drink) //to add drinks into db
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


    public class CodeFirstTest//this is code first
    {
        static void main()
        {
            DrinkRepository repository = new DrinkRepository();
            CoffeeStore st1 = new CoffeeStore() { Eircode = "C15C98E", Location = "O' Connell St. Limerick", IsOpen = true, StoreName = "Starbucks", StoreRating = 0 };
            repository.AddStore(st1);
        }
    }





}