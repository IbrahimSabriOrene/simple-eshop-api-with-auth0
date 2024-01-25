using System;

namespace Product.Models
{
    public class Product
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public decimal? Price { get; init; }
        public string? Image { get; init; }
        public int Stock { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public Guid? SubCategoryId { get; init; }

        public Product()
        {
        }

        public Product(Guid id, string? name, string? description, decimal? price, string? image, int stock, DateTime createdAt,
            DateTime updatedAt, Guid? subCategoryId)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Image = image;
            this.Stock = stock;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.SubCategoryId = subCategoryId;
        }
    }
}