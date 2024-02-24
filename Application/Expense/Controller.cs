using dotnet_mongodb.Data;
using dotnet_mongodb.Application.Shared;
using dotnet_mongodb.Application.User;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;

namespace dotnet_mongodb.Application.Expense;

[ApiController]
[Authorize]
[Route("v1/credit-card/{creditCardId}/expense")]
public class ExpenseController : ControllerBase
{
    private readonly ExpenseService _service;
    private readonly MongoDbContext _db;

    public ExpenseController(ExpenseService service, MongoDbContext db)
    {
        _service = service;
        _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ExpenseEntity>> Get([FromRoute] Guid creditCardId)
    {
        return _db.Expenses.Find(x => x.CreditCardId == creditCardId).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<ExpenseEntity> Get([FromRoute] string id)
    {
        if (Guid.TryParse(id, out Guid guidID) && guidID != Guid.Empty)
        {
            return _db.Expenses.Find(x => x.Id == guidID).FirstOrDefault();
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<Output> Post([FromRoute] Guid creditCardId, [FromBody] ExpenseCreateInput input)
    {
        var output = _service.Execute(input, creditCardId);
        var res = ResponseHttp.Build(output, HttpMethod.Post);
        return StatusCode((int)res.Code, res);
    }
}
