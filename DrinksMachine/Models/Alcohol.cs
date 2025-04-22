using System;

namespace DrinksMachine.Models;
public class Alcohol
{
    public string? Name { get; set; }
    public double Volume { get; set; } // Volume in milliliters
    public double AlcoholContent { get; set; } // Alcohol content in percentage
}
