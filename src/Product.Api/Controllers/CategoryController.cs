using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Models.Requests;

namespace Product.Api.Controllers;

[Route("api/v1/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    
    private ISender _mediator;

    public CategoryController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet("find-all-category")]
    [Authorize]
    public async Task<IActionResult> FindAllCategories()
    {
        var request = new FindAllCategoryRequest();
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }  
    [HttpPut("update-category")]
    [Authorize]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request)
    {
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }  
    [HttpGet("find-category/{id}")]
    [Authorize]
    public async Task<IActionResult> FindCategory(Guid id)
    {
        var request = new FindCategoryRequest(id);
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }  
    [HttpPost("create-category")]
    [Authorize]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
    {
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }
    [HttpDelete("delete-category")]
    [Authorize]
    public async Task<IActionResult> DeleteCategory(DeleteCategoryRequest request)
    {
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }
}