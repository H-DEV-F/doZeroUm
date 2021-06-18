using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPFCNPJ { get; set; }
        [JsonIgnore]
        public virtual List<Contato> Contatos { get; set; }
        [JsonIgnore]
        public virtual Conta Conta { get; set; }
    }
}
