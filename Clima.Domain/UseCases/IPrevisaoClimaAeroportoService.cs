using Clima.Domain.Entities;

namespace Clima.Domain.UseCases
{
    public interface IPrevisaoClimaAeroportoService
    {
        public Task RegistrarClimaAeroporto(PrevisaoClimaAeroporto previsaoClimaAeroporto);
    }
}
