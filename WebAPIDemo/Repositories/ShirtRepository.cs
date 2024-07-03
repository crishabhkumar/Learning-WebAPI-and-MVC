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

        public static List<Shirt> GetShirts()
        {
            return shirtList;
        }

        public static void AddShirt(Shirt shirt)
        {
            shirt.ShirtId = shirtList.Max(x => x.ShirtId) + 1;
            shirtList.Add(shirt);
        }
        public static bool ShirtExists(int id)
        {
            return shirtList.Exists(x=>x.ShirtId == id);   
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirtList.FirstOrDefault(x=>x.ShirtId==id);
        }

        public static Shirt? GetShirtByProperties(string? brand,string? gender,string? color,int? size)
        {
            return shirtList.FirstOrDefault(x => !string.IsNullOrWhiteSpace(brand)
                                            && !string.IsNullOrWhiteSpace(x.Brand)
                                            && x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)
                                            && !string.IsNullOrWhiteSpace(gender)
                                            && !string.IsNullOrWhiteSpace(x.Gender)
                                            && x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)
                                            && !string.IsNullOrWhiteSpace(color)
                                            && !string.IsNullOrWhiteSpace(x.Color)
                                            && x.Color.Equals(color, StringComparison.OrdinalIgnoreCase)
                                            && size.HasValue
                                            && x.Size.HasValue
                                            && size.Value == x.Size.Value);
        }
    }
}
