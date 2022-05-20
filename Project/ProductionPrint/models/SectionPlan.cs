using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class SectionPlan
    {
        public int cmm_mst_sec_id { get; set; }
        public DateTime plan_date { get; set; }
        public List<planItem> planItem { get; set; }
        public List<pln_sec> pln_sec { get; set; }
        public Guid Usr { get; set; }
        public SectionPlan()
        {
            cmm_mst_sec_id = 0;
            plan_date = DateTime.Now;
            planItem = new List<planItem>();
            pln_sec = new List<pln_sec>();
            Usr = new Guid();
        }

        public DataTable SectionSave()
        {
            {
                var objDIc = new Dictionary<string, object>
                {

                    {"pln_sec",new pln_sec("").InvItemListToDataTable(pln_sec)},
                    {"planItem",new planItem("").InvItemListToDataTable(planItem)},
                    {"plan_date",plan_date},
                    {"cmm_mst_sec_id",cmm_mst_sec_id},
                    {"Usr",Usr},  
                    {"typ",1}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Plan_section_wise", objDIc);
            }
        }
        public DataTable SectionPlanSave()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"pln_sec",new pln_sec("").InvItemListToDataTable(pln_sec)},
                    {"planItem",new planItem("").InvItemListToDataTable(planItem)},
                    {"plan_date",plan_date},
                    { "cmm_mst_sec_id",cmm_mst_sec_id},
                    { "Usr",Usr},
                    { "typ",0}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Plan_section_wise", objDIc);
            }
        }



    }


    public class planItem
    {

        public int plan_id { get; set; }
        public int ods_id { get; set; }
        public int order_qty { get; set; }
        // public string Nic { get; set; }
        // public string NewNic { get; set; }


        public planItem(string v)
        {
            plan_id = 0;
            ods_id = 0;
            order_qty = 0;
        }
        public DataTable InvItemListToDataTable(List<planItem> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("ods_id", typeof(int));
            dt1.Columns.Add("order_qty", typeof(int));
            dt1.Columns.Add("plan_id", typeof(int));
            //dt1.Columns.Add("NewNic", typeof(string));


            foreach (var item in lst)
            {

                DataRow _plan = dt1.NewRow();
                _plan["ods_id"] = item.ods_id;
                _plan["order_qty"] = item.order_qty;
                _plan["plan_id"] = item.plan_id;
                //_plan["Nic"] = item.Nic;
                //_plan["NewNic"] = item.NewNic;

                dt1.Rows.Add(_plan);
            }
            return dt1;
        }

    }
}

public class pln_sec
{

    public int id { get; set; }
    public int cmm_mst_sec_id { get; set; }
    public string pln_sec_name { get; set; }
    public DateTime sec_dt { get; set; }
    public bool cs { get; set; }

    public pln_sec(string v)
    {
        id = 0;
        cmm_mst_sec_id = 0;
        pln_sec_name = "";
        sec_dt = DateTime.Now;
        cs = false;
    }
    public DataTable InvItemListToDataTable(List<pln_sec> lst)
    {
        var dt1 = new DataTable();
        dt1.Clear();
        dt1.Columns.Add("id", typeof(int));
        dt1.Columns.Add("cmm_mst_sec_id", typeof(int));
        dt1.Columns.Add("pln_sec_name", typeof(string));
        dt1.Columns.Add("sec_dt", typeof(DateTime));
        dt1.Columns.Add("cs", typeof(bool));
        foreach (var item in lst)
        {

            DataRow _plan = dt1.NewRow();
            _plan["id"] = item.id;
            _plan["cmm_mst_sec_id"] = item.cmm_mst_sec_id;
            _plan["pln_sec_name"] = item.pln_sec_name;
            _plan["sec_dt"] = item.sec_dt;
            _plan["cs"] = item.cs;
            dt1.Rows.Add(_plan);
        }
        return dt1;
    }

}


