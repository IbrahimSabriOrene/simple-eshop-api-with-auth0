using MediatR;

namespace Product.Models.Requests;

public class FindCategoryRequest : IRequest<Category>
{
    public FindCategoryRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}