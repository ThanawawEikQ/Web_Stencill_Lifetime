using MySqlConnector;
using Oracle.ManagedDataAccess.Client;
using System.Data.OleDb;
using System.Data.OracleClient;

namespace Web_Stencill_Lifetime.Data
{
	public class SqlContectDX26
	{
		public static string conStr;
		public static OracleConnection GetConnection()								
		{
			try
			{
                OracleConnection connection = new OracleConnection(conStr);
				return connection;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
