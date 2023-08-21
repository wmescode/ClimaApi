using Clima.Domain.DTOs;
using Clima.Domain.Entities;

namespace Clima.Domain.Factories
{
    public class PrevisaoClimaCidadeFactory
    {
        public static List<PrevisaoClimaCidade> CreateFromDTO(PrevisaoClimaCidadeDTO dto, int codigoCidade)
        {
            var lista = new List<PrevisaoClimaCidade>();

            foreach (var clima in dto.clima)
            {
                var entidade = new PrevisaoClimaCidade(                    
                    codigoCidade: codigoCidade,
                    estado: dto.estado,
                    nome: dto.cidade,
                    dataAtualizacao: dto.atualizado_em,
                    dataPrevisaoClima: clima.data,
                    condicao: clima.condicao,
                    temperaturaMinima: clima.min,
                    temperaturaMaxima: clima.max,
                    indiceUv: clima.indice_uv,
                    condicaoDescricao: clima.condicao_desc
                );

                lista.Add(entidade);
            }

            return lista;
        }
    }
}
