using API.Application.Commands.ConfirmOrder;
using API.Application.Commands.CreateOrder;
using API.Application.Validators;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(
            ILogger<OrderController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return StatusCode(201, _mapper.Map<OrderViewModel>(order));
        }

        [HttpPut]
        [Route("{orderId}/Confirm")]
        public async Task<IActionResult> Confirm(Guid orderId)
        {
            var command = new ConfirmOrderCommand(orderId);

            var validator = new ConfirmOrderCommandValidator();
            if (!validator.Validate(command).IsValid)
            {
                return BadRequest();
            }

            var confirmOrderResponse = await _mediator.Send(command);

            return Ok(confirmOrderResponse);
        }
    }
}
