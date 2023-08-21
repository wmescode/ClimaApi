namespace Clima.Domain.Entities
{
    public class PrevisaoClimaCidade
    {
        public uint Id { get; set; }
        public int CodigoCidade{get;private set;}
        public string Estado { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public DateTime DataPrevisaoClima { get; private set; }
        public string Condicao { get; private set; }
        public short TemperaturaMinima { get;private set; }
        public short TemperaturaMaxima { get; private set; }
        public short IndiceUv { get; private set; }
        public string CondicaoDescricao { get; private set; }

        public PrevisaoClimaCidade(int codigoCidade, 
                                   string estado, 
                                   string nome, 
                                   DateTime dataAtualizacao, 
                                   DateTime dataPrevisaoClima, 
                                   string condicao, 
                                   short temperaturaMinima, 
                                   short temperaturaMaxima, 
                                   short indiceUv, 
                                   string condicaoDescricao)
        {            
            CodigoCidade = codigoCidade;
            Estado = estado;
            Nome = nome;
            DataAtualizacao = dataAtualizacao;
            DataPrevisaoClima = dataPrevisaoClima;
            Condicao = condicao;
            TemperaturaMinima = temperaturaMinima;
            TemperaturaMaxima = temperaturaMaxima;
            IndiceUv = indiceUv;
            CondicaoDescricao = condicaoDescricao;
        }
    }
}
