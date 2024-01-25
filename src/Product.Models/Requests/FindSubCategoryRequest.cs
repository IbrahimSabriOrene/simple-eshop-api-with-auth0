using MediatR;

namespace Product.Models.Requests;

public record FindSubCategoryRequest  (Guid? Id) : IRequest<SubCategory>;
