using MediatR;

namespace Product.Models.Requests;

public class SubCategoryRequest : IRequest<SubCategory>
{

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid ParentCategoryId { get; set; }
}