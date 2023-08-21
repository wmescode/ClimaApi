using Clima.Domain.Entities;

namespace Clima.Domain.Repositories
{
    public interface IPrevisaoClimaCidadeRepository
    {
        Task Insert(PrevisaoClimaCidade previsaoClimaCidade);
    }
}
