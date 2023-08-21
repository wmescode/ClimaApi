using Clima.Domain.Entities;
using Clima.Domain.UseCases;
using Clima.IoC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;

namespace Clima.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaAeroportoController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;
        private readonly IPrevisaoClimaAeroportoService _previsaoClimaAeroportoService;

        public ClimaAeroportoController(IOptions<ApiSettings> apiSettings,
                                        IPrevisaoClimaAeroportoService previsaoClimaAeroportoService)
        {            
            _apiSettings = apiSettings.Value;
            _httpClient = new HttpClient { BaseAddress = new Uri(_apiSettings.BaseAddress) };
            _previsaoClimaAeroportoService = previsaoClimaAeroportoService;
        }
        /// <summary>
        /// Obtém a previsão do clima para um aeroporto específico.
        /// </summary>
        /// <param name="codigoIcao">O código icao do aeroporto.</param>
        /// <response code="200">Retorna a previsão de clima para o aeroporto.</response>
        /// <response code="400">Se houver algum erro no processamento.</response>
        /// <response code="500">Erro interno do servidor.</response>
        //[HttpGet("GetPrevisaoClimaAeroporto/{codigoIcao}")]
        [ProducesResponseType(typeof(PrevisaoClimaCidade), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet("GetPrevisaoClimaAeroporto/{codigoIcao}")]
        public async Task<IActionResult> GetPrevisaoClimaAeroporto(string codigoIcao)
        {
            try
            {
                var response = await _httpClient.GetAsync($"aeroporto/{codigoIcao}");

                if (!response.IsSuccessStatusCode)                
                    throw new Exception("Erro ao obter previsão para o ICAO: {codigoIcao}");                                    
                    

                var previsaoAsString = await response.Content.ReadAsStringAsync();
                var previsaoClimaAeroporto = JsonConvert.DeserializeObject<PrevisaoClimaAeroporto>(previsaoAsString);

                if (previsaoClimaAeroporto == null)
                    return BadRequest("Erro ao processar a previsão");                

                if (previsaoClimaAeroporto != null)
                {
                    previsaoClimaAeroporto.CodigoIcao = codigoIcao;

                        await _previsaoClimaAeroportoService.RegistrarClimaAeroporto(previsaoClimaAeroporto);
                        Log.Warning($"Verificação de clima do aeroporto.\n" +
                                    $"Código ICAO {previsaoClimaAeroporto.CodigoIcao}.\n" +
                                    $"Data atualização: {previsaoClimaAeroporto.AtualizadoEm}\n" +
                                    $"Pressao Atmosférica: {previsaoClimaAeroporto.PressaoAtmosferica}\n" +
                                    $"Umidade: {previsaoClimaAeroporto.Umidade}\n" +
                                    $"Condição climática: {previsaoClimaAeroporto.CondicaoDesc}");                    
                    return Ok(previsaoClimaAeroporto);
                }
                else
                {
                    Log.Error("Erro ao registrar a previsão de clima da cidade");
                    return BadRequest("Erro ao registrar a previsão de clima da cidade");
                }
            }
            catch (Exception ex)
            {
                Log.Error("Previsão Clima Aeroporto: " + ex.Message);

                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
