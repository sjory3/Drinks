using System.Net.Http.Json;
using DrinksWebsite.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace DrinksWebsite.Services
{
    public class DrinkDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _env;

        public DrinkDataService(HttpClient httpClient, IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _env = env;
        }

        public async Task SaveDrinkAsync(Drink drink)
        {
            List<Drink> drinks = await GetDrinksAsync();
            drinks.Add(drink);
            string updatedJson = JsonConvert.SerializeObject(drinks, Formatting.Indented);
            string filePath = Path.Combine(_env.WebRootPath, "data", "Drinks.json");
            await File.WriteAllTextAsync(filePath, updatedJson);
        }

        public async Task<List<Drink>> GetDrinksAsync()
        {
            // Fetch the JSON file directly from the wwwroot/data directory
            List<Drink>? drinks = await _httpClient.GetFromJsonAsync<List<Drink>>("data/Drinks.json");
            return drinks ?? new List<Drink>(); // Handle possible null reference return
        }

        public async Task<List<Liquid>> GetLiquidsAsync()
        {
            // Fetch the JSON file directly from the wwwroot/data directory
            List<Liquid>? liquids = await _httpClient.GetFromJsonAsync<List<Liquid>>("data/Liquids.json");
            return liquids ?? new List<Liquid>(); // Handle possible null reference return
        }

        public async Task<List<Alcohol>> GetAlcoholsAsync()
        {
            // Fetch the JSON file directly from the wwwroot/data directory
            List<Alcohol>? alcohols = await _httpClient.GetFromJsonAsync<List<Alcohol>>("data/Alcohols.json");
            return alcohols ?? new List<Alcohol>(); // Handle possible null reference return
        }
    }
}
