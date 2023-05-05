using MySqlConnector;
using System.Data.OleDb;
using System.Data.OracleClient;

namespace Web_Stencill_Lifetime.Data
{
	public class SqlContect
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
