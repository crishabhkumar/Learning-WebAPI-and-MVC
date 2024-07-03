using WebAPIDemo.Models;

namespace WebAPIDemo.Repositories
{
    public class ShirtRepository
    {

        private static List<Shirt> shirtList = new List<Shirt>()
        {
            new Shirt { ShirtId = 1, Brand = "Nike", Color = "Red", Size = 42, Gender = "Male", Price = 29.99 },
            new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Blue", Size = 40, Gender = "Female", Price = 25.99 },
            new Shirt { ShirtId = 3, Brand = "Puma", Color = "Green", Size = 44, Gender = "Male", Price = 32.99 },
            new Shirt { ShirtId = 4, Brand = "Reebok", Color = "Black", Size = 38, Gender = "Female", Price = 27.99 },
            new Shirt { ShirtId = 5, Brand = "Under Armour", Color = "White", Size = 46, Gender = "Male", Price = 34.99 }
        };

        public static bool ShirtExists(int id)
        {
            return shirtList.Exists(x=>x.ShirtId == id);   
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirtList.FirstOrDefault(x=>x.ShirtId==id);
        }

    }
}
