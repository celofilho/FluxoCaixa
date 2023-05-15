using FluxoCaixa.Api.Controllers;
using FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetSaldoDiario;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;

namespace FluxoCaixa.UnitTests.ControllerTests
{
    public class SaldoControllerTests
    {
        private Mock<IMediator> _mock;
        private SaldoController controller;

        public SaldoControllerTests()
        {
            _mock = new Mock<IMediator>();
            controller = new SaldoController(_mock.Object);
        }

        [Fact]
        public async Task GetSaldoDiarioAsync_Should_ReturnOkOkObjectResult()
        {
            // Arrange
            var request = new GetSaldoDiarioRequest()
            {
                Data = new DateTime()
            };

            List<GetSaldoDiarioResponse> response = new()
            {
                new GetSaldoDiarioResponse
                {
                   Id = new Guid(),
                   Descricao = "Fluxo Teste 1",
                   Debito = 0,
                   Credito = 1000,
                   Data = new DateTime()
                }
            };

            // Act
            _mock.Setup(e => e.Send(request, CancellationToken.None)).ReturnsAsync(response);
            var result = await controller.GetSaldoDiarioAsync(request);

            // Assert
            Assert.NotNull(result);
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }
    }
}
