namespace SistemaTeste.Camadas.Domain.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descriçao { get; set; }

        public int Status { get; set; }
    }
}
