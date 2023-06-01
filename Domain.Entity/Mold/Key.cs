using System;

namespace Domain.Entity
{
    public class Key
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string NombreApp { get; set; }
        public string Valor { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string UsuarioActualizacion { get; set; }
    }
}
