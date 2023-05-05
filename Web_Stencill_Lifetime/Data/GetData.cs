using System.Data;
using Web_Stencill_Lifetime.Model;

namespace Web_Stencill_Lifetime.Data
{
    public class GetData
    {
        private SqlData db = new SqlData();
        public async Task<List<ObjStencil>> GetStencil()
        {
            try
            {
                List<ObjStencil> ls = new List<ObjStencil>();
                DataTable dt = new DataTable();
                string Sql = "SELECT DQCS70.STENCIL_NO,DQCS70.QUANTITY,DQCS70.TOTAL_TIMES,DQCS70.ACCU_TIMES" +
                    ",DQCS71.MODEL,DQCS71.LINE_NO,DQCS71.STENCIL_NO,DQCS71.START_DATE,DQCS71.STOP_DATE,DQCS71.OUTPUT" +
                    ",DQCS71.TOTAL_OUTPUT,DQCS71.ACCU_OUTPUT,DQCS71.STATUS   " +
                    "FROM DQCS71 INNER JOIN DQCS70  " +
                    "ON DQCS70.STENCIL_NO = DQCS71.STENCIL_NO " +
                    "WHERE STOP_DATE IS null";
                dt = await db.QueryDataTable(Sql);
                if(dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ls.Add(new ObjStencil
                        {
                            Stencil_no = dr.ItemArray[0].ToString() ,
                            accu_times = int.Parse( dr.ItemArray[1].ToString()),
                            Total_times =int.Parse( dr.ItemArray[2].ToString()),
                            Model = dr.ItemArray[4].ToString(),
                            line_no = dr.ItemArray[5].ToString(),
                            Start_date = dr.ItemArray[7].ToString()
                        });
                    }
                }
                return ls;
            }
            catch { throw; }
        }
    }
}
