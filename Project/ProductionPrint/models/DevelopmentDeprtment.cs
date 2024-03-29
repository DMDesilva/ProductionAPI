﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class DevelopmentDeprtment
    {
        public int pattern_id { get; set; }
        public int ods_id { get; set; }
        public int cat_id { get; set; }
        public decimal itm_price { get; set; }
        public List<fabric> fabric { get; set; }
        public List<itmsList> itmsList { get; set; }
        public Guid idx { get; set; }
        public Guid usr { get; set; }
        public Guid fabArrId { get; set; }
        public string cat_name { get; set; }
        private string connection { get; set; }

        public DevelopmentDeprtment(string conn)
        {
            pattern_id = 0;
            ods_id = 0;
            cat_id = 0;
            itm_price = 0;
            fabric = new List<fabric>();
            itmsList = new List<itmsList>();
            idx = new Guid();
            usr = new Guid();
            fabArrId = new Guid();
            connection = conn; 
        }
        public DataTable LoadingPatten()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("Select DISTINCT pattern_id,CONCAT( pattern_name ,' - ', pattern_description )as pttn from dbo.system_view_mercha_podata where despathed_date  between (SELECT CONVERT ( date, DATEADD(M, DATEDIFF(M, 0, GETDATE()) -2, 20))) and (SELECT CONVERT ( date, DATEADD(M, DATEDIFF(M, 0, GETDATE()) +3, 0)))");
            }
        }
        public DataSet LoadAllData()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("LoadPttnAndFab", objDIc);
            }
        }
        public DataSet SelectMastItmsCat()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("_Merchandiser_Select_Itms_Cat", objDIc);
            }
        }
        public DataSet LoadFabByPttn()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("FabConsumBypttn", objDIc);
            }
        }
        public DataTable SaveFabConsum()
        {
            {
                var objDIc = new Dictionary<string, object> {

                    {"pattern_id",pattern_id},
                    {"fabric",new fabric("").InvItemListToDataTable(fabric) },
                    {"usr",usr}

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaveFabConsumByPttn", objDIc);
            }
        }

        public DataTable LoadFabForPO()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("LoadForFabCon", objDIc);
            }
        }

        public DataTable FabTransPo()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   // {"pattern_id",pattern_id},
                    {"ods_id",ods_id},
                    {"fabArrId",fabArrId},
                    {"usr",usr}

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Save_fab_trans_po", objDIc);
            }
        }
        public DataTable ItemPriceChange()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   // {"pattern_id",pattern_id},
                    {"idx",idx},
                    {"itm_price",itm_price}

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_itm_price_update", objDIc);
            }
        }

        public DataTable ItmCatSave()
        {
            {
                var objDIc = new Dictionary<string, object> {

                    {"cat_name",cat_name}

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Merchandiser_save_cat", objDIc);
            }
        }

        public DataTable save_itmsCat()
        {
            {
                var objDIc = new Dictionary<string, object>
                {

                    {"cat_id",cat_id},
                    {"itmsList",new itmsList().InvItemListToDataTable(itmsList)},
                    {"usr",usr}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Merchandiser_Itms_Create", objDIc);
            }
        }


    }

    public class fabric
    {
        public int itm_id { get; set; }
        public string sup_item_code { get; set; }
        public decimal consum { get; set; }
        public string sup_item_nme { get; set; }
        public int sb_itm_id { get; set; }
        public string sb_itm_nme { get; set; }
        public fabric(string v)
        {
            itm_id = 0;
            sup_item_code = "";
            consum = 0;
            sup_item_nme = "";
            sb_itm_id = 0;
            sb_itm_nme = "";
        }
        public DataTable InvItemListToDataTable(List<fabric> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("itm_id", typeof(int));
            dt1.Columns.Add("sup_item_code", typeof(string));
            dt1.Columns.Add("consum", typeof(decimal));
            dt1.Columns.Add("sup_item_nme", typeof(string));
            dt1.Columns.Add("sb_itm_id", typeof(int));
            dt1.Columns.Add("sb_itm_nme", typeof(string));
            foreach (var item in lst)
            {

                DataRow _plan = dt1.NewRow();
                _plan["itm_id"] = item.itm_id;
                _plan["sup_item_code"] = item.sup_item_code;
                _plan["consum"] = item.consum;
                _plan["sup_item_nme"] = item.sup_item_nme;
                _plan["sb_itm_id"] = item.sb_itm_id;
                _plan["sb_itm_nme"] = item.sb_itm_nme;

                dt1.Rows.Add(_plan);
            }
            return dt1;
        }

    }



    public class itmsList
    {
        public int itm_id { get; set; }
        public string sup_item_code { get; set; }

        public itmsList()
        {
            itm_id = 0;
            sup_item_code = "";
        }
        public DataTable InvItemListToDataTable(List<itmsList> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("itm_id", typeof(int));
            dt1.Columns.Add("sup_item_code", typeof(string));
            foreach (var item in lst)
            {

                DataRow _cat_list = dt1.NewRow();
                _cat_list["itm_id"] = item.itm_id;
                _cat_list["sup_item_code"] = item.sup_item_code;
            

                dt1.Rows.Add(_cat_list);
            }
            return dt1;
        }
    }

}
