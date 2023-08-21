using Xunit;
using Clima.Domain.Entities;

namespace Clima.Domain.Tests
{
    public class PrevisaoClimaCidadeTests
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var codigoCidade = 1;
            var estado = "SP";
            var nome = "São Paulo";
            var dataAtualizacao = DateTime.Now;
            var dataPrevisaoClima = DateTime.Now.AddDays(1);
            var condicao = "Ensolarado";
            short temperaturaMinima = 20;
            short temperaturaMaxima = 30;
            short indiceUv = 5;
            var condicaoDescricao = "Dia claro e ensolarado.";

            // Act
            var entity = new PrevisaoClimaCidade(codigoCidade, estado, nome, dataAtualizacao, dataPrevisaoClima, condicao, temperaturaMinima, temperaturaMaxima, indiceUv, condicaoDescricao);

            // Assert
            Assert.Equal(codigoCidade, entity.CodigoCidade);
            Assert.Equal(estado, entity.Estado);
            Assert.Equal(nome, entity.Nome);
            Assert.Equal(dataAtualizacao, entity.DataAtualizacao);
            Assert.Equal(dataPrevisaoClima, entity.DataPrevisaoClima);
            Assert.Equal(condicao, entity.Condicao);
            Assert.Equal(temperaturaMinima, entity.TemperaturaMinima);
            Assert.Equal(temperaturaMaxima, entity.TemperaturaMaxima);
            Assert.Equal(indiceUv, entity.IndiceUv);
            Assert.Equal(condicaoDescricao, entity.CondicaoDescricao);
        }
    }
}