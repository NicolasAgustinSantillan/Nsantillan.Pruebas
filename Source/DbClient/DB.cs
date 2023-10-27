using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DbClient
{
    public class DB
    {
        public SqlConnection Conexion { get; private set; }

        public readonly ConcurrentDictionary<string, IDbCommand> Commands;

        public DB(string connectionString)
        {
            this.Conexion = new SqlConnection(connectionString);
        }

        public void AddCommand(IDbCommand command)
        {
            this.Commands.TryAdd(command.CommandText, command);
        }

        public List<T> Execute<T>(string query, System.Data.CommandType commandType) where T : class
        {
            Conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(query, Conexion);
                cmd.CommandType = commandType;
                cmd.ExecuteNonQuery();


                var reader = cmd.ExecuteReader();
                var table = new DataTable();
                table.Load(reader);
                reader.Close();
                return CreateGeneric<T>(table);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conexion.Close();
            }
        }

        private static List<T> CreateGeneric<T>(DataTable table) where T : class
        {
            List<T> lista = new List<T>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                // Crear una instancia de la clase T usando reflection
                var objeto = Activator.CreateInstance<T>();

                // Obtener las propiedades públicas de la clase T
                var propiedades = typeof(T).GetProperties();

                // Recorrer cada propiedad y asignarle el valor de la columna correspondiente
                foreach (var propiedad in propiedades)
                {
                    // Obtener el nombre de la columna que coincide con el nombre de la propiedad
                    var columna = propiedad.Name;

                    object valor = null;
                    try
                    {
                        // Obtener el valor de la columna como un objeto
                        valor = table.Rows[i][columna].ToString();
                    }
                    catch
                    {
                        valor = CreateValueGeneric<T>(table, propiedad, columna, i);
                    }

                    // Convertir el valor al tipo de la propiedad
                    var tipo = Nullable.GetUnderlyingType(propiedad.PropertyType) ?? propiedad.PropertyType;
                    var valorConvertido = Convert.ChangeType(valor, tipo);

                    // Asignar el valor convertido a la propiedad del objeto
                    propiedad.SetValue(objeto, valorConvertido);
                }

                // Agregar el objeto a la lista
                lista.Add(objeto);
            }
            return lista;
        }

        private static object CreateValueGeneric<T>(DataTable table, System.Reflection.PropertyInfo propiedad, string columna, int index) where T : class
        {
            // Obtener las propiedades públicas de la clase T
            var tipo = Nullable.GetUnderlyingType(propiedad.PropertyType) ?? propiedad.PropertyType;

            // Crear una instancia de la clase T usando reflection
            var objeto = Activator.CreateInstance(tipo);

            // Obtener las propiedades públicas de la clase T
            var propiedadesTipo = tipo.GetProperties();

            try
            {
                // Recorrer cada propiedad y asignarle el valor de la columna correspondiente
                foreach (var prop in propiedadesTipo)
                {
                    // Obtener el nombre de la columna que coincide con el nombre de la propiedad
                    var colum = prop.Name;

                    // Obtener el valor de la columna como un objeto
                    string valor = table.Rows[index][colum].ToString();
                    var tipoProp = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    var valorConvertido = Convert.ChangeType(valor, tipoProp);

                    // Asignar el valor convertido a la propiedad del objeto
                    prop.SetValue(objeto, valorConvertido);
                }
            }
            catch (Exception ex)
            {
                return CreateValueGeneric<T>(table, propiedad, columna, index);
            }

            return objeto;
        }
    }
}
