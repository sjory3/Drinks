namespace DrinksWebsite.Models
{
    public class Drink
    {
        public string? Name { get; set; }
        public string? Creator { get; set; }
        public List<Liquid> Liquids { get; set; } = new List<Liquid>();
        public List<Alcohol> Alcohols { get; set; } = new List<Alcohol>();
    }
}
