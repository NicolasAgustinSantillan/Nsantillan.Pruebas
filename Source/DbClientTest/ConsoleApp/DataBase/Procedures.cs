using DbClient;
using System;
using System.Data;

namespace ConsoleApp.DataBase
{
    internal static class Procedures
    {
        public static void AddCommands(DB db)
        {
            foreach (var item in typeof(Procedures).GetFields())
            {
                try
                {
                    db.AddCommand((IDbCommand)item.GetValue(null));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public const string GetMachine = "[Command].[GetMachineByCode]";
    }
}
