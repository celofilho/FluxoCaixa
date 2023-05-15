using FluxoCaixa.Api.Controllers;
using FluxoCaixa.Application.Features.FluxoCaixa.Command.CreateFluxoCaixa;
using FluxoCaixa.Application.Features.FluxoCaixa.Command.DeleteFluxoCaixaById;
using FluxoCaixa.Application.Features.FluxoCaixa.Command.UpdateFluxoCaixa;
using FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetAllFluxoCaixa;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;

namespace FluxoCaixa.UnitTests.ControllerTests
{
    public class FluxoCaixaControllerTests
    {

        private Mock<IMediator> _mock;
        private FluxoCaixaController controller;

        public FluxoCaixaControllerTests()
        {
            _mock = new Mock<IMediator>();
            controller = new FluxoCaixaController(_mock.Object);

        }

        [Fact]
        public async Task CreateFluxoCaixa_Should_ReturnOkOkObjectResult()
        {
            // Arrange
            var request = new CreateFluxoCaixaRequest()
            {
                Descricao = "Fluxo Teste 1",
                Credito = 1000,
                Debito = 0
            };

            // Act
            _mock.Setup(e => e.Send(request, CancellationToken.None)).ReturnsAsync(new Guid());
            var result = await controller.PostAsync(request);

            // Assert
            Assert.NotNull(result);
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(201, statusCodeResult.StatusCode);

        }

        [Fact]
        public async Task GetAllFluxo_Should_ReturnOkOkObjectResult()
        {
            // Arrange
            GetAllFluxoCaixaRequest request = new();

            List<GetAllFluxoCaixaResponse> response = new()
            {
                new GetAllFluxoCaixaResponse
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
            var result = await controller.GetAsync();

            // Assert
            Assert.NotNull(result);
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }

        [Theory]
        [InlineData("7f0e00cf-aa22-4be4-a1fa-1cc220bc5c73")]
        public async Task DeletedFluxoCaixaById_Should_ReturnOkOkObjectResult(Guid id)
        {
            // Arrange
            DeleteFluxoCaixaByIdRequest request = new(id);

            // Act
            _mock.Setup(e => e.Send(request, CancellationToken.None)).ReturnsAsync(new Guid());
            var result = await controller.DeleteByIdAsync(request);

            // Assert
            Assert.NotNull(result);
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }

        [Fact]
        public async Task UpdateFluxoCaixa_Should_ReturnOkOkObjectResult()
        {
            // Arrange
            var request = new UpdateFluxoCaixaRequest()
            {
                Id = new Guid("7f79caed-732c-4637-a9c8-031388fade15"),
                Descricao = "Fluxo Teste 1",
                Credito = 1000,
                Debito = 0
            };

            // Act
            _mock.Setup(e => e.Send(request, CancellationToken.None)).ReturnsAsync(new Guid());
            var result = await controller.UpdateAsync(request);

            // Assert
            Assert.NotNull(result);
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }

    }
}
