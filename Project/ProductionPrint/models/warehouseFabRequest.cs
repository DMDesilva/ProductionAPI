﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class warehouseFabRequest
    {
        public Guid idx { get; set; }
        public int ord_id { get; set; }
        public int itm_id { get; set; }
        public string itmnms { get; set; }
        public int sub_itm_id { get;set;}
        public decimal req_qty { get;set;}
        public List<itemlist> itemlist { get; set; }
        public List<ods_list> ods_list { get; set; }
        public decimal stock_qty { get; set; }
        public string unit { get; set; }
        public string dmg_msg { get; set; }
        public int typ { get; set; }
        public int st { get; set; }
        public Guid usr { get; set; }

        private string connection { get; set; }
        public warehouseFabRequest(string con)
        {
            idx = new Guid();
            ord_id = 0;
            itm_id = 0;
            sub_itm_id = 0;
            req_qty = 0;
            stock_qty = 0;
            unit = "";
            dmg_msg = "";
            itmnms = "";
            typ = 0;
            itemlist = new List<itemlist>();
            ods_list = new List<ods_list>();
            usr = new Guid();
            connection = con;
            st = 0;
        }

        public DataTable LoadDepartments()
        {
            {

                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT dept_id, dept_nme FROM [sysTower].dbo.user_master_dep ORDER BY dept_nme");
            }
        }
        public DataTable LoadReqPo()
        {
            { 

                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [po_no],[fbsids]  ,[itmnms],[req_qty] ,[unit] " +
                    ",[isTest] ,[isBulk] ,[isDamage],[remark],[isTypin] FROM [dbo].[VIEW_werehouse_req_powise]");
            }
        }
        public DataSet SizesGet()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    { "ord_id",ord_id},
                    { "itm_id",itm_id},
                    { "st",st}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("[dbo].[_size_split_ods_TEST]", objDIc);
            }
        }
        public DataSet Load_req_fab_info()
        {//_Load_warehouse_req_fab_info
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("_Load_warehouse_req_fab_info", objDIc);
            }
        }
        public DataSet Load_warehouse_report()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("_Load_warehouse_report", objDIc);
            }
        }

        public DataTable Save_warehouse_fab_req()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"idx",idx},
                    {"itm_id",itm_id},
                    {"itmnms",itmnms},
                    {"sub_itm_id",sub_itm_id},
                    {"req_qty",req_qty},
                    {"unit",unit},
                    {"stock_qty",stock_qty},
                    {"itemlist",new itemlist().InvItemListToDataTable(itemlist)},
                    {"ods_list",new ods_list().InvItemListToDataTable(ods_list)},
                    {"dmg_msg",dmg_msg},
                    {"typ",typ},
                    {"usr",usr}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_save_warehouseFabReq", objDIc);
            }
        }
    }

    public class itemlist
    {
        public string id { get; set; }
        public int ord_id { get; set; }
        public string size { get; set; }
        public int qnty { get; set; }
        public int bln_qnty { get; set; }


        public itemlist()
        {
            id = "";
            ord_id = 0;
            qnty = 0;
            bln_qnty = 0;
            size = "";

        }


        public DataTable InvItemListToDataTable(List<itemlist> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("id", typeof(string));
            dt1.Columns.Add("ord_id", typeof(int));
            dt1.Columns.Add("size", typeof(string));
            dt1.Columns.Add("qnty", typeof(int));
            dt1.Columns.Add("bln_qnty", typeof(int));
            foreach (var item in lst)
            {

                DataRow _itmlists = dt1.NewRow();
                _itmlists["id"] = item.id;
                _itmlists["ord_id"] = item.ord_id;
                _itmlists["size"] = item.size;
                _itmlists["qnty"] = item.qnty;
                _itmlists["bln_qnty"] = item.bln_qnty;

                dt1.Rows.Add(_itmlists);
            }
            return dt1;
        }

    }

    public class ods_list {

        public int ord_id { get; set; }
        public string itm_id { get; set; }
        public int order_qty { get; set; }
        public int add_qnty { get; set; }
        public bool isTest { get; set; }
        public bool isBulk { get; set; }
        public bool isDamage { get; set; }
        public bool isTypin { get; set; }

        public ods_list()
        {
            ord_id = 0;
            itm_id = "";
            order_qty = 0;
            add_qnty = 0;
            isTest = false;
            isBulk = false;
            isDamage = false;
            isTypin = false;
        }

        public DataTable InvItemListToDataTable(List<ods_list> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("ord_id", typeof(int));
            dt1.Columns.Add("itm_id", typeof(string));
            dt1.Columns.Add("order_qty", typeof(int));
            dt1.Columns.Add("add_qnty", typeof(int));
            dt1.Columns.Add("isTest", typeof(bool));
            dt1.Columns.Add("isBulk", typeof(bool));
            dt1.Columns.Add("isDamage", typeof(bool));
            dt1.Columns.Add("isTypin", typeof(bool));

            foreach (var item in lst)
            {

                DataRow _itmlists = dt1.NewRow();
                _itmlists["ord_id"] = item.ord_id;
                _itmlists["itm_id"] = item.itm_id;
                _itmlists["order_qty"] = item.order_qty;
                _itmlists["add_qnty"] = item.add_qnty;
                _itmlists["isTest"] = item.isTest;
                _itmlists["isBulk"] = item.isBulk;
                _itmlists["isDamage"] = item.isDamage;
                _itmlists["isTypin"] = item.isDamage;

                dt1.Rows.Add(_itmlists);

            }
            return dt1;
        }

    }
}

