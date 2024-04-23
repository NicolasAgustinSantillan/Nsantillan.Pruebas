using System.Collections.Generic;

namespace ConsoleApp.DataBase.DTO
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }

        public PaisDTO Pais { get; set; }
        
        public string NombrePersona { get; set; }

        public int EdadPersona { get; set; }
    }
}
