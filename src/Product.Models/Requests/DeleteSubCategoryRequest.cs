using MediatR;

namespace Product.Models.Requests;

public record DeleteSubCategoryRequest
(
    Guid Id 
): IRequest<string>;
