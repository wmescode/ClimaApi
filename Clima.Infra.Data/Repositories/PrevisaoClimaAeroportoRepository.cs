using Clima.Domain.Entities;
using Clima.Domain.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Serilog;
using System.Data;

namespace Clima.Infra.Data.Repositories
{
    public class PrevisaoClimaAeroportoRepository : Repository, IPrevisaoClimaAeroportoRepository
    {
        public PrevisaoClimaAeroportoRepository(SqlConnection connection) : base(connection)
        {
        }

        public async Task Insert(PrevisaoClimaAeroporto previsaoClimaAeroporto)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    await _connection.OpenAsync();

                var query = @"
                INSERT INTO previsao_clima_aeroporto (
                        codigo_icao ,
                        atualizado_em ,
                        pressao_atmosferica ,
                        visibilidade ,
                        vento ,
                        direcao_vento ,
                        umidade ,
                        condicao,
                        condicao_desc ,
                        temp 
                        ) VALUES (
                        @CodigoIcao, 
                        @AtualizadoEm, 
                        @PressaoAtmosferica, 
                        @Visibilidade, 
                        @Vento, 
                        @DirecaoVento, 
                        @Umidade, 
                        @Condicao, 
                        @CondicaoDesc, 
                        @Temp                   
                )";

                await _connection.ExecuteAsync(query, previsaoClimaAeroporto);
            }
            catch (Exception ex) 
            {
                Log.Error("PrevisaoClimaAeroportoRepository.Insert: " + ex.Message);
            }
        }
    }
}
