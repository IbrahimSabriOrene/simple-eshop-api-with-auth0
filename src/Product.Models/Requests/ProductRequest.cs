using MediatR;


namespace Product.Models.Requests;

public class ProductRequest : IRequest<Product>
{
    public Guid? SubCategoryId { get; set; } //Name would be better for this type of thing.
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? Image { get; set; }
    public int Stock { get; set; }
}