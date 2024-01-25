using MediatR;

namespace Product.Models.Requests;

public class CreateCategoryRequest : IRequest<Category>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}