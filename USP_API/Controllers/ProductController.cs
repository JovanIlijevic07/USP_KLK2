using Microsoft.AspNetCore.Mvc;
using USP_Application.Products.Commands;
using USP_Application.Products.Queries;


namespace USP_API.Controllers;

public class ProductController:ApiBaseController
{

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery]GetOneProductQueri queri) => Ok(await Mediator.Send(queri));
    
    [HttpGet]
    public async Task<ActionResult> GetAll()=>Ok(await Mediator.Send(new GetAllProductQueri()));
    
    [HttpPost]
    public async Task<ActionResult> Create( CreateProductCommand command) => Ok(await Mediator.Send(command));
}