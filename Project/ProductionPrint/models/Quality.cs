using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class Quality
    {


        public DataTable Loadpatterns()
        {
            {
              
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [pattern_id] ,[pattern_name] ,[pattern_description]FROM [dbo].[develp_master_pattern]");
            }
        }


    }
}
