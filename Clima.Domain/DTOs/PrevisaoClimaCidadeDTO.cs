namespace Clima.Domain.DTOs
{
    public class PrevisaoClimaCidadeDTO
    {
        public string cidade { get; set; }
        public string estado { get; set; }
        public DateTime atualizado_em { get; set; }
        public List<ClimaDTO> clima { get; set; }
    }

    public class ClimaDTO
    {
        public DateTime data { get; set; }
        public string condicao { get; set; }
        public short min { get; set; }
        public short max { get; set; }
        public short indice_uv { get; set; }
        public string condicao_desc { get; set; }
    }
}
