using Clima.Domain.Entities;
using Clima.Domain.Repositories;
using Clima.Domain.UseCases;

namespace Clima.Application.UseCases
{
    public class PrevisaoClimaAeroportoService : IPrevisaoClimaAeroportoService
    {
        private readonly IPrevisaoClimaAeroportoRepository _repository;
        public PrevisaoClimaAeroportoService(IPrevisaoClimaAeroportoRepository repository)
        {
            _repository = repository;
        }

        public async Task RegistrarClimaAeroporto(PrevisaoClimaAeroporto previsaoClimaAeroporto)
        {
            if(previsaoClimaAeroporto.AtualizadoEm.ToString() == "01/01/0001 00:00:00")
                previsaoClimaAeroporto.AtualizadoEm = DateTime.Now;

            if (string.IsNullOrEmpty(previsaoClimaAeroporto.CondicaoDesc))
                previsaoClimaAeroporto.CondicaoDesc = "Sem informações de condição climática";

            await _repository.Insert(previsaoClimaAeroporto);
        }
    }
}
