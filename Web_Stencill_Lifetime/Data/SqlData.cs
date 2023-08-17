using System.Data;
using Microsoft.VisualBasic;
using MySqlConnector;
using System.Data.OleDb;
using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;

namespace Web_Stencill_Lifetime.Data
{
	public class SqlData
    {
        DataSet DS = new DataSet();
        public async Task<bool> ExecuteNonQueryAsyncData(string Cmd)
		{
			bool Result = false;
			try
			{
				using (OracleConnection conn = SqlContect.GetConnection())
				{
					var commandText = "";
					conn.Open();
					commandText = Cmd;
					OracleCommand cmd = new OracleCommand(commandText, conn);
					await cmd.ExecuteNonQueryAsync();
				}
				return Result = true;
			}
			catch { return Result; throw; }
		}

        public  DataTable QueryDataTable(string SqlCmdIn)
        {

                OracleConnection conn = SqlContect.GetConnection();
                conn.Open();
                OracleCommand odbcc = new OracleCommand();
                odbcc.CommandText = SqlCmdIn;
                odbcc.Connection = conn;
                OracleDataAdapter odbca = new OracleDataAdapter(odbcc);
                DS.Clear();

                odbca.Fill(DS);

                return DS.Tables[0];
        
        }
		public DataTable QueryDataTableDX26(string SqlCmdIn)
		{

			OracleConnection conn = SqlContectDX26.GetConnection();
			conn.Open();
			OracleCommand odbcc = new OracleCommand();
			odbcc.CommandText = SqlCmdIn;
			odbcc.Connection = conn;
			OracleDataAdapter odbca = new OracleDataAdapter(odbcc);
			DS.Clear();

			odbca.Fill(DS);

			return DS.Tables[0];

		}

	}
}

