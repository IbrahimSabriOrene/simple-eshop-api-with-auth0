using MediatR;

namespace Product.Models.Requests;

public class DeleteCategoryRequest : IRequest<string>
{
    public Guid Id { get; set; }
}