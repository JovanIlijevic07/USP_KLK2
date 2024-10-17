using Microsoft.AspNetCore.Mvc;
using USP_API.Services;
using USP_Application.Users.Commands;

namespace USP_API.Controllers;

public class UserController(IUserService userService, IProductService productService) : ApiBaseController
{
    //ako ides ALT+ENTER mozes da ceo ovaj kod prebacujes gore
    //public class UserController(IUserService userService, IProductService productService) ovako postane
    //private readonly IUserService _userService;
    //private readonly IProductService _productService;
    //public UserController(IUserService userService, IProductService productService)
    //{
    //    _userService = userService;
    //    _productService = productService;
    //}

    [HttpPost]
    public async Task<ActionResult> Edit(EditUserCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    [HttpGet]
    public async Task<ActionResult> Test()
    {
        return Ok();
    }
}