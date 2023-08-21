using Clima.Domain.Entities;
using Clima.Domain.Repositories;
using Clima.Domain.UseCases;

namespace Clima.Application.UseCases
{
    public class PrevisaoClimaCidadeService : IPrevisaoClimaCidadeService
    {
        private readonly IPrevisaoClimaCidadeRepository _previsaoClimaCidadeRepository;

        public PrevisaoClimaCidadeService(IPrevisaoClimaCidadeRepository previsaoClimaCidadeRepository)
        {
            _previsaoClimaCidadeRepository = previsaoClimaCidadeRepository;
        }

        public async Task RegistrarClimaCidade(PrevisaoClimaCidade previsaoClimaCidade)
        {
            await _previsaoClimaCidadeRepository.Insert(previsaoClimaCidade);
        }
    }
}
