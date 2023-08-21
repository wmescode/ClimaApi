using Clima.Domain.DTOs;
using Clima.Domain.Entities;
using Clima.Domain.Factories;
using Clima.Domain.UseCases;
using Clima.IoC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;

namespace ClimaApi.Controllers
{
    /*
     * https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityCode}
     * https://brasilapi.com.br/api#operation/climapredictionwithoutdays(/cptec/v1/clima/previsao/:cityCode)/cptec/v1/clima/aeroporto/{icaoCode}
     */
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaCidadeController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;
        private readonly IPrevisaoClimaCidadeService _previsaoClimaCidadeService;

        public ClimaCidadeController(IOptions<ApiSettings> apiSettings,
                                     IPrevisaoClimaCidadeService previsaoClimaCidadeService)
        {            
            _apiSettings = apiSettings.Value;
            _httpClient = new HttpClient{BaseAddress = new Uri(_apiSettings.BaseAddress)};
            _previsaoClimaCidadeService = previsaoClimaCidadeService; 
        }
        /// <summary>
        /// Obtém a previsão do clima para uma cidade específica.
        /// </summary>
        /// <param name="codigoCidade">O código da cidade.</param>
        /// <response code="200">Retorna a lista de previsões do clima.</response>
        /// <response code="400">Se houver algum erro no processamento.</response>
        /// <response code="500">Erro interno do servidor.</response>
        //[HttpGet("GetPrevisaoClimaCidade/{codigoCidade}")]
        [ProducesResponseType(typeof(List<PrevisaoClimaCidade>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet("GetPrevisaoClimaCidade/{codigoCidade}")]
        public async Task<IActionResult> GetPrevisaoClimaCidade(int codigoCidade)
        {
            try
            {                
                var response = await _httpClient.GetAsync($"previsao/{codigoCidade}");

                if (!response.IsSuccessStatusCode)
                    return BadRequest($"Erro ao obter previsão para o CEP: {codigoCidade}");

                var previsaoAsString = await response.Content.ReadAsStringAsync();
                var previsaoDTO = JsonConvert.DeserializeObject<PrevisaoClimaCidadeDTO>(previsaoAsString);

                if (previsaoDTO == null)
                    return BadRequest("Erro ao processar a previsão");

                var previsaoClimaCidade = PrevisaoClimaCidadeFactory.CreateFromDTO(previsaoDTO, codigoCidade);

                if (previsaoClimaCidade != null)
                {
                    foreach (var climaCidade in previsaoClimaCidade)
                    {
                        await _previsaoClimaCidadeService.RegistrarClimaCidade(climaCidade);
                        Log.Warning($"Verificação de clima da cidade.\n" +
                                    $"Cidade {climaCidade.Nome}.\n" +
                                    $"Data Previsão: {climaCidade.DataPrevisaoClima}\n" +
                                    $"Temperatura mínima: {climaCidade.TemperaturaMinima}\n" +
                                    $"Temperatura máxima: {climaCidade.TemperaturaMaxima}\n" +
                                    $"Condição climática: {climaCidade.CondicaoDescricao}");
                    }
                    return Ok(previsaoClimaCidade);
                }
                else
                {
                    Log.Error("Erro ao registrar a previsão de clima da cidade");
                    return BadRequest("Erro ao registrar a previsão de clima da cidade");
                }
            }
            catch (Exception ex)
            {
                Log.Error("Previsão Clima Cidade: " + ex.Message);

                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
