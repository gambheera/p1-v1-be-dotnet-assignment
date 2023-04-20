using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Queries.GetAvailableFlights;
using API.Application.Validators;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<FlightsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FlightsController(
        ILogger<FlightsController> logger,
        IMediator mediator,
        IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{destinationAirportName}")]
    public async Task<ActionResult<IEnumerable<FlightResponse>>> GetAvailableFlights(string destinationAirportName)
    {
        var query = new GetAvailableFlightsQuery(destinationAirportName);

        var validator = new GetAvailableFlightsQueryValidator();
        if (!validator.Validate(query).IsValid)
        {
            return BadRequest();
        }

        var flightList = await _mediator.Send(query);

        return Ok(flightList);
    }
}
