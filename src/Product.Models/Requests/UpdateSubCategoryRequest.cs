using MediatR;

namespace Product.Models.Requests;

public record UpdateSubCategoryRequest(
 Guid Id, 
 string Name,
 string Description,
 Guid ParentCategoryId
 ) : IRequest<SubCategory>;