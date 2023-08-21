using Xunit;
using Clima.Domain.Factories;
using Clima.Domain.DTOs;
using System.Linq;

namespace Clima.Domain.Tests
{
    public class PrevisaoClimaCidadeFactoryTests
    {
        [Fact]
        public void CreateFromDTO_ShouldReturnCorrectNumberOfEntities()
        {
            var dto = new PrevisaoClimaCidadeDTO
            {
                cidade = "Teste",
                estado = "TE",
                atualizado_em = DateTime.Now,
                clima = new List<ClimaDTO>
                {
                    new ClimaDTO(),
                    new ClimaDTO()
                }
            };

            var result = PrevisaoClimaCidadeFactory.CreateFromDTO(dto, 1);

            Assert.Equal(dto.clima.Count, result.Count);
        }

        // Adicione mais testes aqui, por exemplo, para validar se os valores do DTO são corretamente mapeados para as entidades.
    }
}