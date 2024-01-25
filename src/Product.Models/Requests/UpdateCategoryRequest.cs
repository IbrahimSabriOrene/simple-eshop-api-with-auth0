using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Product.Models.Requests;

public class UpdateCategoryRequest : IRequest<Category>
{
     public Guid Id { get; set; }
     [Required] public string Name { get; set; } = null!;
     [Required] public string Description { get; set; } = null!;
     
}