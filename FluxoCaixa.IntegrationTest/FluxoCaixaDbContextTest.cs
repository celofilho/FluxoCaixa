using FluxoCaixa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.IntegrationTest
{
    public class FluxoCaixaDbContextTest
    {
        private FluxoCaixaDbContext _fluxoCaixaContext;
        public FluxoCaixaDbContextTest()
        {
            var dbOptions = new DbContextOptionsBuilder<FluxoCaixaDbContext>()
                .UseInMemoryDatabase(databaseName: "FluxoCaixaDbConnection").Options;

            _fluxoCaixaContext = new FluxoCaixaDbContext(dbOptions);
        }

        [Fact]
        public async void Check_Save_DataBase()
        {
            // Arrange
            var create = new Domain.Entities.FluxoCaixa()
            {
                Id = new Guid(),
                Descricao = "Fluxo Teste 1",
                Credito = 1000,
                Debito = 0,
                Saldo = 1000,
                Data = new DateTime()
            };

            // Act
            await _fluxoCaixaContext.FluxoCaixa.AddAsync(create);
            await _fluxoCaixaContext.SaveChangesAsync();

            // Assert
            //create.Id.
        }
    }
}
