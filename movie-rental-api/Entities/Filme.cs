using System.ComponentModel.DataAnnotations;

namespace movie_rental_api.Entities
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        public int IdImdb { get; set; }
        public int IdCliente { get; set; }
        public string? NomeCliente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }

    }
}
