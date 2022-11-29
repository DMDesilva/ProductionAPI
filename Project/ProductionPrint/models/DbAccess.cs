using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class DbAccess
    {

        private string _conStr = "";
        public DbAccess(string Connection_string)
        {
            _conStr = Connection_string;
        }

        public bool AddData(string tableName, Dictionary<string, object> fieldAndValueList)
        {
            var filedList = "";
            var valueList = "";
            foreach (var item in fieldAndValueList)
            {
                filedList = filedList == "" ? ("[" + item.Key.Trim() + "]") : (filedList + ",[" + item.Key.Trim() + "]");
                valueList = valueList == "" ? ("@" + item.Key.Trim()) : (valueList + ",@" + item.Key.Trim());
            }
            var str = "Insert into " + tableName + " (" + filedList + ") values(" + valueList + ")";
            return ExecuteNonQueryCmd(str, fieldAndValueList) > 0;
        }

        public object LoadDatatableBySP(string v)
        {
            throw new NotImplementedException();
        }

        //public object LoadRecordToDictionary(string v, Dictionary<string, object> dictionary)
        //{
        //    throw new NotImplementedException();
        //}

        public bool UpdateTable(string tableName, Dictionary<string, object> fieldAndValueList, List<String> UpdateConditions)
        {
            var filedList = "";
            var whereClauseList = "";
            foreach (var item in fieldAndValueList)
            {
                if (!UpdateConditions.Contains(item.Key))
                {
                    filedList = (filedList == "") ? ("[" + item.Key + "]=@" + item.Key) : (filedList + ",[" + item.Key + "]=@" + item.Key);
                }
                else
                {
                    whereClauseList = (whereClauseList == "") ? ("[" + item.Key.Trim() + "]=@" + item.Key.Trim()) : (whereClauseList + " and [" + item.Key.Trim() + "]=@" + item.Key.Trim());
                }
            }
            var str = "Update " + tableName + " set " + filedList + " where " + whereClauseList;
            return ExecuteNonQueryCmd(str, fieldAndValueList) > 0;
        }

        public DataTable LoadDatatableBySP(string Stored_Procedure_Name, Dictionary<string, object> parmDictionary)
        {
            using (var da = new SqlDataAdapter(Stored_Procedure_Name, _conStr))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (var item in parmDictionary)
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@" + item.Key.Replace(' ', '_'), item.Value));
                }
                using (var dt = new DataTable())
                {
                    da.Fill(dt);
                    dt.TableName = "table1";
                    return dt;
                }
            }
        }
        public int ExcecuteNonQuearyCmd(string cmdText)
        {
            using (var conn = new SqlConnection(_conStr))
            {
                using (var cmd = new SqlCommand(cmdText.Replace(@"/", ""), conn))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataSet LoadDataSetBySP(string Stored_Procedure_Name, Dictionary<string, object> parmDictionary)
        {

            using (var da = new SqlDataAdapter(Stored_Procedure_Name, _conStr))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (var item in parmDictionary)
                {
                    da.SelectCommand.Parameters.Add(new SqlParameter("@" + item.Key.Replace(' ', '_'), item.Value));
                }
                using (var ds = new DataSet())
                {
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        ds.Tables[i].TableName = "Table" + i.ToString();
                    }


                    return ds;
                }
            }
        }



        public DataTable ExecuteSP(string Stored_Procedure_Name, Dictionary<string, object> parmDictionary)
        {
            var dt = new DataTable();
            var conn = new SqlConnection(_conStr);
            SqlCommand cmd;
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = Stored_Procedure_Name;
                if (!(parmDictionary is null))
                {
                    foreach (var item in parmDictionary)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key.Replace(' ', '_'), item.Value);
                    }
                }


                cmd.CommandTimeout = 3600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
            }
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
            {
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dt);
            }
            return dt;

        }

        public Dictionary<string, object> LoadRecordToDictionary(string cmdText)
        {
            return LoadRecToDic(cmdText);
        }

        private Dictionary<string, object> LoadRecToDic(string cmdText)
        {
            using (var conn = new SqlConnection(_conStr))
            {
                SqlDataReader dr;
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                }
                return LoadReaderToDictionary(dr);
            }
        }

        private int ExecuteNonQueryCmd(String cmdString, Dictionary<string, object> parametersAndValueList)
        {
            var retValue = 0;
            var conn = new SqlConnection(_conStr);
            try
            {
                using (var cmd = new SqlCommand(cmdString, conn))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    foreach (var item in parametersAndValueList)
                    {
                        cmd.Parameters.Add(new SqlParameter("@" + item.Key.Replace(' ', '_'), item.Value));
                    }
                    retValue = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                var err = e;
                //  ErrorHandler.ErrorHandler.Log("ExecuteNonQueryCmd", e.Message, e.Source);
#if DEBUG
                throw;
#endif
            }
            finally
            {
                conn.Close();
            }
            return retValue;
        }

        private Dictionary<string, object> LoadReaderToDictionary(DbDataReader dr)
        {
            var retDic = new Dictionary<string, object>();
            if (!dr.HasRows) return retDic;
            dr.Read();
            for (var i = 0; i < dr.FieldCount; i++)
                retDic.Add(dr.GetName(i), dr[i]);
            return retDic;
        }

        public Dictionary<string, string> LoadPairToDictionary(string cmdText)
        {
            var retDic = new Dictionary<string, string>();

            using (var conn = new SqlConnection(_conStr))
            {
                SqlDataReader dr;
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (!dr.HasRows) return retDic;

                    while (dr.Read())
                    {
                        retDic.Add(dr[0].ToString(), dr[1].ToString());
                    }
                }
                return retDic;
            }
        }

        public DataTable FillDataTable(string str)
        {
            return FillDataSet(str).Tables[0];
        }
        public DataSet FillDataSet(string str)
        {
            var retDs = new DataSet();
            try
            {
                using (var da = new SqlDataAdapter(str, _conStr))
                {
                    using (var ds = new DataSet())
                    {
                        da.Fill(ds);
                        retDs = ds;
                    }
                }
            }
            catch (Exception e)
            {
                var err = e;
                // ErrorHandler.ErrorHandler.Log("DBAccess-FillDataSet", "Qry :" + str + Environment.NewLine + "Error : " + e.Message, e.Source);
#if DEBUG
                throw;
#endif
            }
            return retDs;
        }

        private string getAppDomainData(string settingsName)
        {
            var conStr = AppDomain.CurrentDomain.GetData(settingsName);
            var returnVal = AppDomain.CurrentDomain.GetData(settingsName);
            if (AppDomain.CurrentDomain.GetData(settingsName) == null)
            {
                returnVal = "";
            }
            return returnVal.ToString();
        }

        public DataTable FillDataTable(string str, string filterCondidtion, string orderBy)
        {
            str = string.Format("{0}{1}{2}", str, ((filterCondidtion.Length > 0) ? (" where  " + filterCondidtion) : ("")), ((orderBy.Length > 0) ? (" order by " + orderBy) : ("")));
            return FillDataSet(str).Tables[0];
        }


        public List<List<object>> FillDataList(string cmdText)
        {
            return ExecuteReaderCmd(cmdText);
        }

        public List<object> GetListByValue(string cmdStr) // get result first line without column Names
        {
            return ExecuteReaderCmd(cmdStr)[0];
        }
        private List<List<object>> ExecuteReaderCmd(string cmdText)
        {
            using (var conn = new SqlConnection(_conStr))
            {
                SqlDataReader dr;
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                }
                return AddReaderToList(dr, false);
            }
        }

        private List<List<object>> AddReaderToList(DbDataReader dr, bool withHeadders)
        {
            var outerlist = new List<List<object>>();
            if (!dr.HasRows) return outerlist;
            if (withHeadders)
            {
                var hedderList = new List<object>();
                for (var i = 0; i < dr.FieldCount; i++)
                    hedderList.Add(dr.GetName(i));
                outerlist.Add(hedderList);
            }
            while (dr.Read())
            {
                var innerlist = new List<object>();
                for (var i = 0; i < dr.FieldCount; i++)
                    innerlist.Add(dr[i]);
                outerlist.Add(innerlist);
            }
            return outerlist;
        }

        public object ExecuteScalarCmd(string cmdString)
        {
            object retObj = null;
            var conn = new SqlConnection(_conStr);
            try
            {
                using (var cmd = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    retObj = cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                var err = e;
                //ErrorHandler.ErrorHandler.Log("DBAccess-FillDataSet", "Qry " + cmdString + Environment.NewLine + "Error : " + e.Message, e.Source);
#if DEBUG
                throw;
#endif
            }
            finally
            {
                conn.Close();
                conn = null;
            }
            return retObj;
        }

        public Dictionary<string, string> AddRecordToDictionary(string cmdText)
        {
            using (var conn = new SqlConnection(_conStr))
            {
                SqlDataReader dr;
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();
                }
                return AddReaderToDictionary(dr);
            }
        }

        private Dictionary<string, string> AddReaderToDictionary(SqlDataReader dr)
        {
            var retDic = new Dictionary<string, string>();
            if (!dr.HasRows) return retDic;
            dr.Read();
            for (var i = 0; i < dr.FieldCount; i++)
                retDic.Add(dr.GetName(i), dr[i].ToString());
            return retDic;
        }



    }
}
