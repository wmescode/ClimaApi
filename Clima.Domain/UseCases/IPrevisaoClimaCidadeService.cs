using Clima.Domain.Entities;

namespace Clima.Domain.UseCases
{
    public interface IPrevisaoClimaCidadeService
    {
        public Task RegistrarClimaCidade(PrevisaoClimaCidade previsaoClimaCidade);        
    }
}
