using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Models.Requests;
using Product.Service.Subcategory;


namespace Product.Api.Controllers;

[Route("api/v1/subcategory")]
[ApiController]
public class SubCategoryController : ControllerBase
{
    private ISender _mediator;

    public SubCategoryController(ISender mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("find-all-subcategory"), Authorize]
    public async Task<IActionResult> FindAllSubCategories()
    {
        var request = new FindAllSubcategoriesRequest();
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }  
    [HttpPut("update-subcategory"),Authorize]
    public async Task<IActionResult> UpdateSubCategory(UpdateSubCategoryRequest request)
    {
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }  
    [HttpGet("find-subcategory/{id}"), Authorize]
    public async Task<IActionResult> FindSubCategory(Guid id)
    {
        var request = new FindSubCategoryRequest(id);
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }  
    [HttpPost("create-subcategory"), Authorize]

    public async Task<IActionResult> CreateSubCategory(SubCategoryRequest request)
    {
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }
    [HttpDelete("delete-subcategory"), Authorize]
    public async Task<IActionResult> DeleteSubCategory(DeleteSubCategoryRequest request)
    {
        var send = await _mediator.Send(request);
        return Ok(send); 
        
    }
}