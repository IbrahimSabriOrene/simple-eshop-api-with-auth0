using MediatR;

namespace Product.Models.Requests;

public record GetProductById  (Guid? Id) : IRequest<Product>;

   
    