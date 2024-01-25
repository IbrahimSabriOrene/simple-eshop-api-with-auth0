using MediatR;

namespace Product.Models.Requests;

public record UpdateProductRequest(

    Guid Id,
    Guid? SubCategoryId, //Name would be better,
    string? Name,
    string? Description,
    decimal? Price,
    string? Image,
    int Stock

) : IRequest<Product>;
