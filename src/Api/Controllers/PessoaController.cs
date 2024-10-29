using System;
using System.Threading.Tasks;
using Domain.Command;
using Domain.Interfaces;
using Domain.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GetPessoaQuery = Domain.Query.GetPessoaQuery;

namespace EstudoGraphQL.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IQueryHandler<GetPessoaQuery, GetPessoaQueryResponse> _query;
    private readonly ICommandHandler<CreatePessoaCommand, CreatePessoaCommandResponse> _command;

    public PessoaController(IQueryHandler<GetPessoaQuery, GetPessoaQueryResponse> query, ICommandHandler<CreatePessoaCommand, CreatePessoaCommandResponse> command)
    {
        _query = query;
        _command = command;
    }

    [HttpGet]
    public async Task<ActionResult> Get(string? id)
    {
        return Ok( await _query.Handle(new GetPessoaQuery("Consulta controller", string.IsNullOrEmpty(id)? Guid.Empty : Guid.Parse(id))));
    }
    
    [HttpPost]
    public ActionResult Post(CreatePessoaCommand dto)
    {
        var id = _command.Handle(dto);
        return Ok(id);
    }
}