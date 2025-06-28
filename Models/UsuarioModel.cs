using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_web.Models
{
 
    [Table("Usuario")]
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Senha { get; set; } = "";
    }
}