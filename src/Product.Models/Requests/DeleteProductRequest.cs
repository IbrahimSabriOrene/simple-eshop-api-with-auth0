using MediatR;

namespace Product.Models.Requests;

public record DeleteProductRequest(Guid Id) : IRequest<string>;
