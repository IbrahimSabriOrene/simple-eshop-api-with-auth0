namespace Product.Models;


public record SubCategory(
    Guid Id,
    string Name,
    string Description,
    // ICollection<Guid>? ProductIds, // Connect This to the SubCategoryProducts
    Guid ParentCategoryId
    //DateTime CreatedAt,
    //DateTime UpdatedAt
    );
