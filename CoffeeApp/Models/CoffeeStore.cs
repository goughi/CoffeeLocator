using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace CoffeeApp.Models
{
    public enum OpeningHour {  [Display(Name = "5:00 AM")]AM0500 = 0500, [Display(Name = "6:00 AM")]AM0600 = 0600, [Display(Name = "7:00 AM")]AM0700 = 0700,
        [Display(Name = "8:00 AM")] AM0800 = 0800,
        [Display(Name = "8:30 AM")] AM0830 = 0830,
        [Display(Name = "9:00 AM")]AM0900 = 0900
    }
    public enum ClosingHour
    {
        [Display(Name = "4:00 PM")]PM1600 = 1609,
        [Display(Name = "5:00 PM")]PM1700 = 1700,
        [Display(Name = "5:30 PM")]PM1730 = 1730,
        [Display(Name = "6:00 PM")]PM1800 = 1800,
        [Display(Name = "6:30 PM")]PM1830 = 1830,
        [Display(Name = "7:00 PM")]PM1900 = 1900
    }
    public enum Rating { [Display(Name = "1")]one, [Display(Name = "2")]two, [Display(Name = "3")]three, [Display(Name = "4")]four, [Display(Name = "5")]five }
    public enum DrinkSize { tall, grande, vendi }
    public class CoffeeStore
    {
        public String StoreName { get; set; }
        [Key]
        public String Eircode { get; set; }

        public String Location { get; set; }
        public bool IsOpen
        {
            get
            {
                if((DateTime.Now.Hour >= (int)OpeningTime) && (DateTime.Now.Hour <= (int)ClosingTime))
                {
                    return true;
                }
                else { return false; }
            }
        }
        [Range(0,5,ErrorMessage ="rating must be between 1 and 5")]
        public double StoreRating { get; }
      
        public OpeningHour OpeningTime { get; set; }
       
        public ClosingHour ClosingTime { get; set; }

        public virtual ICollection<Drink> Drinks { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
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
    public class Review
    {
        public int ReviewID { get; set; }
        public String CustomerName { get; set; }
        public String Comment { get; set; }
        public Rating Rating { get; set; }

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
        public DbSet<Review> Reviews { get; set; }
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

       public void AddDrink(Drink drink)
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

       public void AddReview(Review review)
        {
            using (DrinkContext db = new DrinkContext())
            {
                try
                {
                    db.Reviews.Add(review);
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
            
                CoffeeStore st1 = new CoffeeStore() { Eircode = "C15C98E", Location = "O' Connell St. Limerick", OpeningTime = OpeningHour.AM0700, ClosingTime = ClosingHour.PM1730, StoreName = "Starbucks" };
                repository.AddStore(st1);
                Drink latte = new Drink() { DrinkName = "Cafe Latte", DrinkID = 001, DrinkSize = DrinkSize.grande, Price = 3.40, Eircode = st1.Eircode};
                Review r1 = new Review() { ReviewID = 999, CustomerName = "mg1", Comment = "The coffee is way too expensive", Rating = Rating.two,  Eircode = st1.Eircode };
            repository.AddDrink(latte);
            repository.AddReview(r1);
            
        }
    }
}