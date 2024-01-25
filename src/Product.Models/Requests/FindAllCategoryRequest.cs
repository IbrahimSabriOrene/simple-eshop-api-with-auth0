using MediatR;

namespace Product.Models.Requests;

public class FindAllCategoryRequest : IRequest<IEnumerable<Category>>
{
    
}