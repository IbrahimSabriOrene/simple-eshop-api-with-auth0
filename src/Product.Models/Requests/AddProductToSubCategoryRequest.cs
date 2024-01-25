using MediatR;

namespace Product.Models.Requests;

public class AddProductToSubCategoryRequest : IRequest<string>, IRequest<SubCategory>
{
    public Guid ProductId { get; set; }
    public Guid SubCategoryId { get; set; }
}