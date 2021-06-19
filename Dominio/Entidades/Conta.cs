using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Conta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
        public int AgenciaId { get; set; }
        public int TipoConta { get; set; }
        public int NRConta { get; set; }
        public Decimal Saldo { get; set; }
        [JsonIgnore]
        public virtual Agencia Agencia { get; set; }
    }
}
