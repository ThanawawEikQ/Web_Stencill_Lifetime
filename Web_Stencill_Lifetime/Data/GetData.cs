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
					"WHERE  DQCS71.STATUS Is Null";
                dt = db.QueryDataTable(Sql);

                if (dt != null&& dt.Rows.Count >0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string Acc = dr.ItemArray[1].ToString();
                        if(Acc != "")
                        {
                            ls.Add(new ObjStencil
                            {
                                Stencil_no = dr.ItemArray[0].ToString(),
                                accu_times = int.Parse(dr.ItemArray[3].ToString()),
                                Total_times = int.Parse(dr.ItemArray[2].ToString()),
                                Model = dr.ItemArray[4].ToString(),
                                line_no = dr.ItemArray[5].ToString(),
                                Start_date = dr.ItemArray[7].ToString()
                            });
                        }
                   
                    }
                }

                string SqlDx26 = "SELECT DQCS70.STENCIL_NO,DQCS70.QUANTITY,DQCS70.TOTAL_TIMES,DQCS70.ACCU_TIMES" +
                   ",DQCS71.MODEL,DQCS71.LINE_NO,DQCS71.STENCIL_NO,DQCS71.START_DATE,DQCS71.STOP_DATE,DQCS71.OUTPUT" +
                   ",DQCS71.TOTAL_OUTPUT,DQCS71.ACCU_OUTPUT,DQCS71.STATUS   " +
                   "FROM DQCS71 INNER JOIN DQCS70  " +
                   "ON DQCS70.STENCIL_NO = DQCS71.STENCIL_NO " +
				   "WHERE  DQCS71.STATUS  Is Null";
                dt = db.QueryDataTableDX26(SqlDx26);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string Acc = dr.ItemArray[1].ToString();
                        if (Acc != "")
                        {
                            ls.Add(new ObjStencil
                            {
                                Stencil_no = dr.ItemArray[0].ToString(),
                                accu_times = int.Parse(dr.ItemArray[3].ToString()),
                                Total_times = int.Parse(dr.ItemArray[2].ToString()),
                                Model = dr.ItemArray[4].ToString(),
                                line_no = dr.ItemArray[5].ToString(),
                                Start_date = dr.ItemArray[7].ToString()
                            });
                        }
                    }
                }
                return ls;
            }
            catch { throw; }
        }
        public async Task<List<ObjStencillAll>> GetStencilAll()
        {
            try
            {
                List<ObjStencillAll> objs = new List<ObjStencillAll>();
                DataTable dt = new DataTable();
                string Sql = "SELECT DQCS70.STENCIL_NO, DQCS70.STENCIL_REVISE_NO, DQCS70.MODEL,DQCS70.DESCRP" +
                    ",DQCS70.STENCIL_PN,DQCS70.QUANTITY, DQCS70.PATTERN, DQCS70.TOTAL_TIMES, DQCS70.ACCU_TIMES" +
                    ", DQCS70.STATUS FROM DQCS70 ";
                dt = db.QueryDataTable(Sql);
                if (dt != null)
                {
                    string Get = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        Get = dr.ItemArray[0].ToString();
                        Get = Get.Substring(0, 1);
                        string Acc = dr.ItemArray[8].ToString();
                        if (Get != "0"&&Acc !="")
                            objs.Add(new ObjStencillAll
                            {
                                STENCIL_NO = dr.ItemArray[0].ToString(),
                                STENCIL_REV = dr.ItemArray[1].ToString(),
                                MODEL = dr.ItemArray[2].ToString(),
                                DESCRP = dr.ItemArray[3].ToString(),
                                STENCIL_PN = dr.ItemArray[4].ToString(),
                                TOTAL_TIME = dr.ItemArray[7].ToString(),
                                ACCU_TIMES = dr.ItemArray[8].ToString(),
                                STATUS = dr.ItemArray[9].ToString()
                            });
                    }
                }
                string Sqls = "SELECT DQCS70.STENCIL_NO, DQCS70.STENCIL_REVISE_NO, DQCS70.MODEL,DQCS70.DESCRP" +
                    ",DQCS70.STENCIL_PN,DQCS70.QUANTITY, DQCS70.PATTERN, DQCS70.TOTAL_TIMES, DQCS70.ACCU_TIMES" +
                    ", DQCS70.STATUS FROM DQCS70 ";
                dt = db.QueryDataTableDX26(Sqls);
                if (dt != null)
                {
                    string Get = "";
  
                    foreach (DataRow dr in dt.Rows)
                    {
                        Get = dr.ItemArray[0].ToString();
                        Get = Get.Substring(0, 1);
                        string Acc = dr.ItemArray[8].ToString();

                        if (Get != "0" && Get != "1" && Acc != "")
                            objs.Add(new ObjStencillAll
                            {
                                STENCIL_NO = dr.ItemArray[0].ToString(),
                                STENCIL_REV = dr.ItemArray[1].ToString(),
                                MODEL = dr.ItemArray[2].ToString(),
                                DESCRP = dr.ItemArray[3].ToString(),
                                STENCIL_PN = dr.ItemArray[4].ToString(),
                                TOTAL_TIME = dr.ItemArray[7].ToString(),
                                ACCU_TIMES = dr.ItemArray[8].ToString(),
                                STATUS = dr.ItemArray[9].ToString()
                            });
                        
                    }
                }
                return objs;
            }
            catch { throw; }
        }
        private async Task<string> CalCycle(string Acc, string Pattern)
        {
            string Result = "";
            try
            {
                if (Acc != "")
                {
                    int ac = int.Parse(Acc);
                    int Pat = int.Parse(Pattern);
                    int Res = ac * Pat;
                    Result = Res.ToString();
                }
                return Result;
            }
            catch { throw; }
        }
        public async Task<List<ObDashboard>> GetCountUseinLine()
        {
            try
            {
                int TotalAll = 0;
                int TotalInline = 0;
                string COunt = "";
                List<ObDashboard> ls = new List<ObDashboard>();
                DataTable dt = new DataTable();
                string Sql = "SELECT COUNT(*) FROM DQCS71 WHERE STOP_DATE IS null AND STATUS != 'C'";
                dt = db.QueryDataTable(Sql);
                if (dt != null)
                    foreach (DataRow item in dt.Rows)
                    {
                        TotalAll = int.Parse(item.ItemArray[0].ToString());
                    }

                string Sql2 = "SELECT COUNT(*) FROM DQCS71 WHERE STOP_DATE IS null  AND STATUS != 'C'";
                dt = db.QueryDataTableDX26(Sql2);
                if (dt != null)
                    foreach (DataRow item in dt.Rows)
                    {
                        TotalAll += int.Parse(item.ItemArray[0].ToString());

                    }
                //--------------------------------------------------------------------------------------
                string Sql3 = "SELECT COUNT(*) FROM DQCS70 WHERE ACCU_TIMES IS Not null AND ACCU_TIMES != '0' ";
                dt = db.QueryDataTable(Sql3);
                if (dt != null)
                    foreach (DataRow item in dt.Rows)
                    {
                        TotalInline = int.Parse(item.ItemArray[0].ToString());
                    }

                string Sql4 = "SELECT COUNT(*) FROM DQCS70  WHERE ACCU_TIMES IS Not null AND ACCU_TIMES != '0' AND STENCIL_NO != '06'";
                dt = db.QueryDataTableDX26(Sql4);
                if (dt != null)
                    foreach (DataRow item in dt.Rows)
                    {
                        TotalInline += int.Parse(item.ItemArray[0].ToString());

                    }


                ls.Add(new ObDashboard
                {
                    TotalInline = TotalAll.ToString(),
                    TotalStencil = TotalInline.ToString(),
                }); ;

                return ls;

            }
            catch { throw; }
        }
    }
}
