using Carepatron.BLL.Services.Interfaces;
using Carepatron.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Carepatron.Controllers;

public class ClientsController : BaseController
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] string search)
    {
        var result = await _clientService.GetAll(search);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientModel model)
    {
        var result = await _clientService.Create(model);

        return Ok(result);
    }
}