using System;

namespace Domain.Entity.Models
{
    public class UserPublicKey
    {
        public long Id { get; set; }
        
       
        public string Algoritmo { get; set; }
        public string Formato { get; set; }
        public string LlavePublica { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string UsuarioActualizacion { get; set; }
    }
}
