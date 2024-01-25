using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Models.Requests;
using Product.Service.Product;

namespace Product.Api.Controllers;

[Route("api/v1/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private ISender _mediator;
    private ProductsGetAll _all;

    
    public ProductController(ISender mediator, ProductsGetAll all)
    {
        _mediator = mediator;
        _all = all;
    }

    [HttpPost("create-product")]
    [Authorize]
    public async Task<IActionResult> CreateProduct(ProductRequest request)
    {
        
            var send = await _mediator.Send(request);
        return Ok(send); 
        
    }  
    [HttpGet("get-product/{id}")]
    [Authorize]
    public async Task<IActionResult> GetProduct(Guid? id)
    {
        var request = new GetProductById(id);
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }  
    [HttpGet("get-all-product")]
    [Authorize]
    public async Task<IActionResult> GetAllProduct( )
    {
        var products = await _all.GetAllService();
        
        return Ok(products); 
        
    }  
    
    [HttpPut("update-product")]
    [Authorize]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
    {
        var send = await _mediator.Send(request);
        return Ok(send); 
    }  
    [HttpDelete("delete-product")]
    [Authorize]
    public async Task<IActionResult> Delete(DeleteProductRequest request)
    {
        await Task.CompletedTask;
        var send = await _mediator.Send(request);
        return Ok(send); 
    }  
    
    
}
