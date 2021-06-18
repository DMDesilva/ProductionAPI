using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class BuyerCatergory
    {
        public Guid idx { get; set; }
        public string product { get; set; }
        public string buyer { get; set; }
        public string buyer_category { get; set; }
        public string buyer_code { get; set; }
        public string buyer_po_code { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string invoice_name { get; set; }
        public string invoice_address { get; set; }
        public string contract_title { get; set; }
        public string contract_name { get; set; }
        public string email_address { get; set; }
        public string m_num { get; set; }
        public string p_num { get; set; }
        public string extention { get; set; }
        public string fax_no { get; set; }
        public int shipment_terms { get; set; }
        public string port { get; set; }
        public string c_account_no { get; set; }
        public string vat { get; set; }
        public string svat { get; set; }
        public int inv_typ { get; set; }
        public string currency { get; set; }
        public int paymnt_terms { get; set; }
        public string credit_limit { get; set; }
        public string payment_name { get; set; }
        public string paymnt_email { get; set; }
        public string paymnt_mobile_no { get; set; }
        public string email_paymnt_inv { get; set; }
        public string email_shipment { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public string img3 { get; set; }
        public string img4 { get; set; }
        public Guid usr { get; set; }
        public int typ { get; set; }
        private string connection { get; set; }

        public BuyerCatergory(string conn)
        {
            idx = new Guid();
            product = "";
            buyer = "";
            buyer_category = "";
            buyer_code = "";
            buyer_po_code = "";
            address = "";
            city = "";
            state = "";
            postal_code = "";
            country = "";
            invoice_name = "";
            invoice_address = "";
            contract_title = "";
            contract_name = "";
            email_address = "";
            m_num = "";
            p_num = "";
            extention = "";
            fax_no = "";
            shipment_terms =0;
            port = "";
            c_account_no = "";
            vat = "";
            svat = "";
            inv_typ =0;
            currency = "";
            paymnt_terms = 0;
            credit_limit = "";
            payment_name = "";
            paymnt_email = "";
            paymnt_mobile_no = "";
            email_paymnt_inv = "";
            email_shipment = "";
            img1 = "";
            img2 = "";
            img3 = "";
            img4 = "";
            usr= new Guid();
            typ = 0;
            connection = conn;
        }
        public DataTable LoadBuyerCatergory()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT  [Idx],[id]  ,[buyer] ,[buyer_category],[buyer_code] ,[buyer_po_code] ,[address],[city] ,[state] ,[postal_code] ,[country],[invoice_name],[invoice_address] ,[contract_title],[contract_name],[email_address],[m_num] ,[p_num],[extention] ,[port] ,[c_account_no],[vat],[svat] ,[fax_no],[paymnt_terms] ,[Pay_terms],[currency] ,[credit_limit],[payment_name],[paymnt_email],[paymnt_mobile_no],[email_paymnt_inv] ,[email_shipment] ,[shipment_terms]  ,[shipmet_terms],[inv_typ],[invtyp],[img1],[img2],[img3],[img4] FROM [dbo].[VIEW_Merchandiser_Buyer_details]");
            }
        }
        public DataTable LoadingShipmentTerms()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [id] ,[shipmet_terms],[isActive] FROM [dbo].[_Merchandiser_MAST_Shipment_terms]");
            }
        }
        
        public DataTable LoadingInvTyp()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [id] ,[inv_typ] ,[IsActive] FROM [dbo].[_Mechandiser_MAST_Inv_typ]");
            }
        }
        public DataTable LoadingPaymntTrms()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT  [id],[Pay_terms] ,[IsActive] FROM [dbo].[_Merchandiser_MAST_Pymnt_terms]");
            }
        }

        public DataTable Save_BuyerCat()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"idx",idx},
                {"product",product},
                {"buyer",buyer},
                {"buyer_category", buyer_category},
                {"buyer_code",buyer_code},
                {"buyer_po_code",buyer_po_code },
                {"address",address},
                {"city",city},
                {"state",state},
                {"postal_code",postal_code},
                {"country",country},
                {"invoice_name",invoice_name},
                {"invoice_address",invoice_address},
                {"contract_title",contract_title}, 
                {"contract_name",contract_name},
                {"email_address",email_address},
                {"m_num",m_num},
                {"p_num",p_num},
                {"extention",extention},
                {"fax_no",fax_no},
                {"shipment_terms",shipment_terms},
                {"port",port},
                {"c_account_no",c_account_no},
                {"vat",vat},
                {"svat",svat},
                {"inv_typ",inv_typ}, 
                {"currency",currency},
                {"paymnt_terms",paymnt_terms},
                {"credit_limit",credit_limit},
                {"payment_name",payment_name},
                {"paymnt_email",paymnt_email}, 
                {"paymnt_mobile_no",paymnt_mobile_no},
                {"email_paymnt_inv",email_paymnt_inv },
                {"email_shipment",email_shipment },
                {"img1",img1},
                {"img2",img2},
                {"img3",img3},
                {"img4",img4},
                {"usr",usr},
                {"typ",typ}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Mechandiser_buyer_save", objDIc);
            }
        }



    }
}
