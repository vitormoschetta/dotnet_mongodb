using dotnet_mongodb.Shared;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mongodb.Todo;

[ApiController]
[Route("v1/todo")]
public class TodoController : ControllerBase
{
    private readonly TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<Output> Get()
    {
        var output = _service.Execute();
        var res = ResponseHttp.Build(output, HttpMethod.Get);
        return StatusCode((int)res.Code, res);
    }

    [HttpGet("{id}")]
    public ActionResult<ResponseHttp> Get(string id)
    {
        var guidID = Guid.Parse(id);
        var output = _service.Execute(guidID);
        var res = ResponseHttp.Build(output, HttpMethod.Get);
        return StatusCode((int)res.Code, res);
    }

    [HttpPost]
    public ActionResult<Output> Post([FromBody] TodoCreateInput input)
    {
        var output = _service.Execute(input);
        var res = ResponseHttp.Build(output, HttpMethod.Post);
        return StatusCode((int)res.Code, res);
    }
}
