using MediatR;

namespace Product.Models.Requests;

public class FindAllSubcategoriesRequest : IRequest<IEnumerable<SubCategory>>
{
    
}