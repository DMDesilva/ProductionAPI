using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class smv_operation
    {
        public int id { get; set; }
        public string op_name { get; set; }
        private string connection { get; set; }
        public smv_operation(string conn)
        {
            id = 0;
            op_name = "";
            connection = conn;
        }

        public DataTable LoadOperation()
        {
            {
            
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [id] ,[op_name] ,[isActive], 0 as smv,0 as mtype,0 as foot,'' as att1,'' as att2,'' as remk  FROM [dbo].[_Merchandiser_MAST_SMV_operation]");
            }
        }
    }
}
