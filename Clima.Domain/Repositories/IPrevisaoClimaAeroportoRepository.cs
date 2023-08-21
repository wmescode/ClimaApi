using Clima.Domain.Entities;

namespace Clima.Domain.Repositories
{
    public interface IPrevisaoClimaAeroportoRepository
    {
        Task Insert(PrevisaoClimaAeroporto previsaoClimaAeroporto);
    }
}
