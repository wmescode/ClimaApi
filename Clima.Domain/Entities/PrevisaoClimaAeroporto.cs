
namespace Clima.Domain.Entities
{
    public class PrevisaoClimaAeroporto
    {
        public uint Id { get; set; }
        public string CodigoIcao { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int PressaoAtmosferica { get; set; }
        public string Visibilidade { get; set; }
        public int Vento { get; set; }
        public int DirecaoVento { get; set; }
        public int Umidade { get; set; }
        public string Condicao { get; set; }
        public string CondicaoDesc { get; set; }
        public int Temp { get; set; }

        public PrevisaoClimaAeroporto(string codigoIcao, 
                                      DateTime atualizadoEm, 
                                      int pressaoAtmosferica, 
                                      string visibilidade, 
                                      int vento, 
                                      int direcaoVento, 
                                      int umidade, 
                                      string condicao, 
                                      string condicaoDesc, 
                                      int temp)
        {            
            CodigoIcao = codigoIcao;
            AtualizadoEm = atualizadoEm;
            PressaoAtmosferica = pressaoAtmosferica;
            Visibilidade = visibilidade;
            Vento = vento;
            DirecaoVento = direcaoVento;
            Umidade = umidade;
            Condicao = condicao;
            CondicaoDesc = condicaoDesc;
            Temp = temp;
        }
    }
}
