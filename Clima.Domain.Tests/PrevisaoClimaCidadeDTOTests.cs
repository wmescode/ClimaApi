using Xunit;
using Clima.Domain.DTOs;

namespace Clima.Domain.Tests
{
    public class PrevisaoClimaCidadeDTOTests
    {
        [Fact]
        public void Properties_ShouldGetAndSetCorrectly()
        {
            // Arrange
            var cidade = "São Paulo";
            var estado = "SP";
            var atualizado_em = DateTime.Now;
            var climaList = new List<ClimaDTO>
            {
                new ClimaDTO
                {
                    data = DateTime.Now,
                    condicao = "Ensolarado",
                    min = 20,
                    max = 30,
                    indice_uv = 5,
                    condicao_desc = "Dia claro e ensolarado."
                }
            };

            var dto = new PrevisaoClimaCidadeDTO
            {
                cidade = cidade,
                estado = estado,
                atualizado_em = atualizado_em,
                clima = climaList
            };

            // Assert
            Assert.Equal(cidade, dto.cidade);
            Assert.Equal(estado, dto.estado);
            Assert.Equal(atualizado_em, dto.atualizado_em);
            Assert.Equal(climaList, dto.clima);
        }
    }
}