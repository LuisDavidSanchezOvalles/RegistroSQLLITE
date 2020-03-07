using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroSQLLITE.Entidades
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }

        public Persona()
        {
            PersonaId = 0;
            Nombres = string.Empty;
        }
    }
}
