namespace VagProd.WebApi.Request;

public record ProductAddRequest(
    string Title,
    decimal Price,
    string? Description,
    string? Category,
    string? Image);