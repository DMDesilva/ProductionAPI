using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class PaymentRelese
    {

        public DateTime paydate { get; set; }
        public Guid frght_ForwrdId { get; set; }
        public Guid usr { get; set; }
        public string acc_no { get; set; }

        public List<awbArray> awbArray { get; set; }
        public List<frgIn> frgIn { get; set; }
        private string Connection { get; set; }


        public PaymentRelese(string conn)
        {
            Connection = conn;
            paydate = DateTime.Now;
            acc_no = "";
            frght_ForwrdId = new Guid();
            usr = new Guid();
            awbArray = new List<awbArray>();
            frgIn = new List<frgIn>();
        }

        public DataTable LoadPayAccount()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT [Id],[acc_no] FROM [dbo].[Ex_Im_Shipment_Accounts]");
        }


        public DataTable SavePaymentRelese()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"paydate",paydate},
                    {"acc_no",acc_no},
                  //{"frght_ForwrdId",frght_ForwrdId},
                    {"awbArray",new awbArray().InvItemListToDataTable(awbArray)},
                    {"frgIn",new frgIn().InvItemListToDataTable(frgIn)},
                    {"usr",usr}

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SavePayRelese", objDIc);
            }
        }


    }

    public class awbArray
    {
        public Guid awB_No { get; set; }

        public awbArray()
        {
            awB_No = new Guid();
        }

        public DataTable InvItemListToDataTable(List<awbArray> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("awB_No", typeof(Guid));

          //  dt1.Columns.Add("ods_id", typeof(int));
          //  dt1.Columns.Add("comment", typeof(string));
            foreach (var item in lst)
            {

                DataRow _Desplan = dt1.NewRow();
                _Desplan["awB_No"] = item.awB_No;
             //   _Desplan["ods_id"] = item.ods_id;
              //  _Desplan["comment"] = item.comment;

                dt1.Rows.Add(_Desplan);
            }
            return dt1;
        }
    }

    public class frgIn
    {
        public string frwrd_InvNo { get; set; }
        public decimal payAm { get; set; }

        public frgIn()
        {
            frwrd_InvNo = "";
            payAm =0;
        }
        public DataTable InvItemListToDataTable(List<frgIn> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("frwrd_InvNo", typeof(string));
            dt1.Columns.Add("payAm", typeof(decimal));
            
            //dt1.Columns.Add("ods_id", typeof(int));
            //dt1.Columns.Add("comment", typeof(string));
            foreach (var item in lst)
            {

                DataRow _Desplan = dt1.NewRow();
                _Desplan["frwrd_InvNo"] = item.frwrd_InvNo;
                _Desplan["payAm"] = item.payAm;
                //_Desplan["ods_id"] = item.ods_id;
                //_Desplan["comment"] = item.comment;

                dt1.Rows.Add(_Desplan);
            }
            return dt1;
        }
    }

}
