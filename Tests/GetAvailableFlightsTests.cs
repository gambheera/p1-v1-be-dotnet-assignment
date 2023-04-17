using API.ApiResponses;
using API.Application.Queries.GetAvailableFlights;
using API.Controllers;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests
{
    public class GetAvailableFlightsTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly FlightsController _controller;
        private Mock<ILogger<FlightsController>> _loggerMock;

        public GetAvailableFlightsTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<FlightsController>>();
            _mapperMock = new Mock<IMapper>();
            _controller = new FlightsController( _loggerMock.Object, _mediatorMock.Object, _mapperMock.Object);
        }


        [Theory]
        [InlineData("ist", "[\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2022-03-02T00:07:00+05:30\",\r\n    \"arrival\": \"2022-03-02T15:07:00+05:30\",\r\n    \"priceFrom\": 6228\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2022-11-01T13:10:00+05:30\",\r\n    \"arrival\": \"2022-11-02T01:10:00+05:30\",\r\n    \"priceFrom\": 8778\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2021-10-01T11:21:00+05:30\",\r\n    \"arrival\": \"2021-10-01T23:21:00+05:30\",\r\n    \"priceFrom\": 10915\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2021-04-01T09:43:00+05:30\",\r\n    \"arrival\": \"2021-04-01T20:43:00+05:30\",\r\n    \"priceFrom\": 14096\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2021-07-01T06:37:00+05:30\",\r\n    \"arrival\": \"2021-07-01T08:37:00+05:30\",\r\n    \"priceFrom\": 14585\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2021-06-01T20:14:00+05:30\",\r\n    \"arrival\": \"2021-06-01T21:14:00+05:30\",\r\n    \"priceFrom\": 10760\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2021-02-01T19:44:00+05:30\",\r\n    \"arrival\": \"2021-02-02T01:44:00+05:30\",\r\n    \"priceFrom\": 14444\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2022-04-01T20:45:00+05:30\",\r\n    \"arrival\": \"2022-04-02T06:45:00+05:30\",\r\n    \"priceFrom\": 8584\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2021-09-01T06:01:00+05:30\",\r\n    \"arrival\": \"2021-09-01T13:01:00+05:30\",\r\n    \"priceFrom\": 6586\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2021-08-01T19:45:00+05:30\",\r\n    \"arrival\": \"2021-08-02T03:45:00+05:30\",\r\n    \"priceFrom\": 7370\r\n  },\r\n  {\r\n    \"departureAirportCode\": \"DUB\",\r\n    \"arrivalAirportCode\": \"IST\",\r\n    \"departure\": \"2021-01-01T06:10:00+05:30\",\r\n    \"arrival\": \"2021-01-01T15:10:00+05:30\",\r\n    \"priceFrom\": 2736\r\n  }\r\n]")]
        [InlineData("wfwew", "[]")]
        [InlineData("", "[]")]
        public async Task GetObjectFormData_ReturnsOkResult(string destinationAirportName, string expectedJson)
        {
            try
            {
                var expectedData = expectedJson != null ? JsonConvert.DeserializeObject<List<FlightResponse>>(expectedJson) : null;

                var mockData = MockDataGenerator.GenerateFlightData(destinationAirportName);

                // Act
                var actual = await GetAvailableFlights(mockData, destinationAirportName);

                // Assert
                if (expectedData == null)
                {
                    var notFoundResult = Assert.IsType<NotFoundResult>(actual);
                    Assert.Equal(404, notFoundResult.StatusCode);
                }
                else
                {

                    var okResult = Assert.IsType<OkObjectResult>(actual.Result);
                    var response = Assert.IsType<ActionResult<IEnumerable<FlightResponse>>>(okResult.Value);
                    Assert.IsType<List<FlightResponse>>(response.Value);
                    //Assert.Equal(expectedData, response.Data);
                    Assert.Equal(JsonConvert.SerializeObject(expectedData), JsonConvert.SerializeObject(response.Value));

                }

            }
            catch (Exception ex)
            { throw; }
        }

        private async Task<ActionResult<IEnumerable<FlightResponse>>> GetAvailableFlights(List<FlightResponse> flightData, string destinationAirportName)
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(x => x.Send(It.IsAny<GetAvailableFlightsQuery>(), default)).ReturnsAsync(flightData);

            var controller = new FlightsController( _loggerMock.Object, mockMediator.Object, _mapperMock.Object);
            var result = await controller.GetAvailableFlights(destinationAirportName);

            return (OkObjectResult)result.Result;
        }
    }
}
