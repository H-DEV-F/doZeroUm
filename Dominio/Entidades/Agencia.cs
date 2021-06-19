using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        [JsonIgnore]
        public virtual List<Conta> Contas { get; set; }
    }
}
