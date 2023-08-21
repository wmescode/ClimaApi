using Clima.Domain.Entities;
using Clima.Domain.Repositories;
using Serilog;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Clima.Infra.Data.Repositories
{
    public class PrevisaoClimaCidadeRepository : Repository, IPrevisaoClimaCidadeRepository
    {
        public PrevisaoClimaCidadeRepository(SqlConnection connection) : base(connection)
        {
        }

        public async Task Insert(PrevisaoClimaCidade previsaoClimaCidade)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    await _connection.OpenAsync();

                var query = @"
                INSERT INTO previsao_clima_cidade (
                    codigo_cidade, 
                    estado,
                    nome,
                    data_atualizacao,
                    data_previsao_clima,
                    condicao,
                    temperatura_minima,
                    temperatura_maxima,
                    indice_uv,
                    condicao_descricao
                ) VALUES (
                    @CodigoCidade,
                    @Estado,
                    @Nome,
                    @DataAtualizacao,
                    @DataPrevisaoClima,
                    @Condicao,
                    @TemperaturaMinima,
                    @TemperaturaMaxima,
                    @IndiceUv,
                    @CondicaoDescricao
                )";

                await _connection.ExecuteAsync(query, previsaoClimaCidade);
                                
            }
            catch (Exception ex) 
            {
                Log.Error("PrevisaoClimaCidadeRepository.Insert: " + ex.Message);
            }
        }
    }
}
