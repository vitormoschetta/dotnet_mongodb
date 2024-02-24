using Microsoft.AspNetCore.Mvc;

namespace dotnet_mongodb.Application.User;

[ApiController]
[Route("v1/credit-card")]
public class AuthController : ControllerBase
{
    private readonly UserService _service;

    public AuthController(UserService service)
    {
        _service = service;
    }
}
