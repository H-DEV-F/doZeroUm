using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Contato
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TipoContato { get; set; }
        public string Telefone { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
    }
}
