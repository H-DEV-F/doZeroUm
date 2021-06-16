using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Contato
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TipoContato { get; set; }
        public int Telefone { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
