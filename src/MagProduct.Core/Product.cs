using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MagProduct.Core;

public class Product
{
 
    public int Id { get; set; }
    public string Title { get; private set; } 
    public decimal Price { get; private set; }
    public string? Description { get; private set; }
    public string? Category { get; private set; } 
    public string? Image { get; private set; }
    public Rating? Rating { get; private set; }

    public void CreateRating(Rating rating)
    {
        this.Rating = rating;
    }
    
    
    
    public Product() { }
    
    [JsonConstructor]
    public Product(
        int id, string title, decimal price, string? description, 
        string? category, string? image, Rating? rating)
    {
        Id = id;
        Title = title;
        Price = price;
        Description = description;
        Category = category;
        Image = image;
        Rating = rating;
    }
    
    private Product(
        
        string title,
        decimal price, 
        string? description, 
        string? category, 
        string? image,
        Rating? rating)
    {
        Title = title;
        Price = price;
        Description = description;
        Category = category;
        Image = image;
        Rating = rating;;
    }
    public static Product Create(
        string title,
        decimal price,
        string? description,
        string? category,
        string? image,
        Rating? rating)
    {
        return new Product(title, price, description, category, image, rating);
    }
}

public class Rating
{
    //[JsonConverter(typeof(DecimalRoundConverter))]
    [Column("Rating_Rate")]
    public double Rate { get; set; }
    [Column("Rating_Count")]
    public int Count { get; set; }
   
    
    [JsonConstructor]
    public Rating(double rate, int count)
    {
        Rate = rate;
        Count = count;
    }
    
}

public class DecimalRoundConverter : JsonConverter<double>
{
    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Чтение числа из JSON
        double value = reader.GetDouble();
        
        // Округление до 2 знаков после запятой
        return Math.Round(value, 2);
    }

    public override  void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    {
        // Запись округленного значения
        writer.WriteNumberValue(Math.Round(value, 2));
    }
}

// public class RatingMap
// {
//     public double Rating_Rate { get; set; }
//     public int Rating_Count { get; set; }
//     public RatingMap(double rating_Rate, int rating_Count)
//     {
//         Rating_Rate = rating_Rate;
//         Rating_Count = rating_Count;
//     }
//     public Rating GetRating()=>new Rating(Rating_Rate,  Rating_Count); 
// }

// {
// "id" : 1,
// "title" : "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
// "price" : 109.95,
// "description" : "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
// "category" : "men's clothing",
// "image" : "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_t.png",
// "rating" : {
//     "rate" : 3.9,
//     "count" : 120
// }
// }