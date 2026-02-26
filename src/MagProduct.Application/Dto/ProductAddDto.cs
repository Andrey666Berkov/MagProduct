using MagProduct.Core;

namespace MagProduct.Application.Dto;

public record ProductAddDto(
    string Title,
    decimal Price,
    string? Description,
    string? Category,
    string? Image,
    Rating? Rating);