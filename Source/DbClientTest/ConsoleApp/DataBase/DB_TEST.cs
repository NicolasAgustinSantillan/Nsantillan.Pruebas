using System.Collections.Generic;
using System.Configuration;
using DbClient;
using ConsoleApp.DataBase.DTO;

namespace ConsoleApp.DataBase
{
    public class DB_TEST
    {
        public DB DB { get; }
        public DB_TEST()
        {
            DB = new DB(ConfigurationManager.ConnectionStrings["TEST"].ConnectionString);
        }

        public List<PersonaDTO> ObtenerPersonas()
        {
            string query = $@"SELECT PE.IdPersona, 
                      PE.NombrePersona ,
                      PE.EdadPersona ,
                      PA.IdPais,
                      PA.NombrePais,
					  PII.IdIdioma,
					  PII.NombreIdioma
                      FROM [PP].[Personas] AS PE 
					  INNER JOIN [PP].[Paises] PA ON PE.IdPais = PA.IdPais
					  INNER JOIN [PP].[Idiomas] PII ON PII.IdIdioma = PA.IdIdioma
                      ORDER BY PE.EdadPersona ASC;";

            return DB.Execute<PersonaDTO>(query, System.Data.CommandType.Text);
        }
    }
}
