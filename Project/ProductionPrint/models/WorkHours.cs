using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class WorkHours
    {
        public DateTime workdate { get; set; }
        public int ord_Id { get; set; }
        public int plant_Id { get; set; }
        public int sec_Id { get; set; }
        public int sub_sec_Id { get; set; }
        public int qnty { get; set; }
        public DateTime frmTime { get; set; }
        public DateTime toTime { get; set; }
        public int workHours { get; set; }
        public int smo { get; set; }
        public int type { get; set; }
        public int Whours { get; set; }
        public string Ip { get; set; }
        public int braekTime { get; set; }
        public int id { get; set; }
        public string Img { get; set; }
        public Guid CreatedBy { get; set; }
        private string Connection { get; set; }

        public WorkHours(string conn)
        {
            workdate = DateTime.Now;
            ord_Id = 0;
            plant_Id = 0;
            sec_Id = 0;
            sub_sec_Id = 0;
            qnty = 0;
            frmTime = DateTime.Now;
            toTime = DateTime.Now;
            workHours = 0;
            smo = 0;
            type = 0;
            id = 0;
            Img = "";
            CreatedBy = new Guid();
            Connection = conn;

        }

        public DataTable GetSection(int pId)
        {
            return (new DbAccess(Connection)).FillDataTable("select DISTINCT(section_id),section_name  FROM [dbo].[VIEW_Plant_bySection] where plant_id='" + pId.ToString() + "'");
        }

        public DataTable GetSubSection(int pId, int SId)
        {
            return (new DbAccess(Connection)).FillDataTable("select DISTINCT([sub_sec_id]) ,[sub_sec_name]  FROM[dbo].[VIEW_Plant_bySection] where[section_id]='" + SId.ToString() + "' and plant_id ='" + pId.ToString() + "'");
        }

        public DataTable GetSubSectionBy()
        {
            return (new DbAccess(Connection)).FillDataTable("select DISTINCT([sub_sec_id]) ,[sub_sec_name]  FROM[dbo].[VIEW_Plant_bySection] where[section_id]=2");
        }

        public DataTable GetWorkHours()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT Idx, [Id],[trans_date],[ord_Id],[po_no],[plant_Id] ,[plant_name],[sec_Id],[section_name],[sub_sec_Id],[sub_sec_name],[start_time] ,[end_time],[smo],[work_hour],[qnty]FROM [dbo].[VIEW_WorkHours] where trans_date= CONVERT(date,[dbo].[GetSLCurrTime] ())");
        }
        // 
        public DataTable TotalQuantity(int sec_Id, int ord)
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT ISNULL(sum([qnty]),0) as tot FROM [dbo].[prdctn_poprod_transa_daywrkhours_efficiency] where [sec_Id]='" + sec_Id.ToString()+ "' and ord_Id='"+ord.ToString()+"'");
        }
        public DataTable DeleteWorkHours(Guid Idx)
        {

            {
                var objDIc = new Dictionary<string, object>
                {

                   {"Idx",Idx}

                 };
                var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("DeleteWorkHover", objDIc);
                return dt;
                // return (new DbAccess(Connection)).("Delete FROM [dbo].[prdctn_lineby_worker_count_hourly] where Idx='" + Idx.ToString() + "'");
            }
        }

        public DataTable DeleteSweingPrd(Guid Idx)
        {

            {
                var objDIc = new Dictionary<string, object>
                {

                   {"Idx",Idx}

                 };
                var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("DeleteSweingProd", objDIc);
                return dt;
                // return (new DbAccess(Connection)).("Delete FROM [dbo].[prdctn_lineby_worker_count_hourly] where Idx='" + Idx.ToString() + "'");
            }
        }
        public DataTable LoadOrderList()
        {
            var obj = new Dictionary<string, object>();
            //{
            //    var objDIc = new Dictionary<string, object> {

            //       {"",1}

            //};
            var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("OrdList", obj);
            return dt;
        }

        public DataTable SaveWork()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"trans_date",workdate},
                   {"ord_Id",ord_Id},
                   {"plant_Id",plant_Id},
                   {"sec_Id",sec_Id},
                   {"sub_sec_Id",sub_sec_Id},
                   {"qnty",qnty},
                   {"Whours",Whours},
                  /// {"start_time",frmTime},
                  // {"end_time",toTime},
                  // {"workHours",workHours},
                   {"smo",smo},
                  {"CreatedBy",CreatedBy}
            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaveEfficency", objDIc);
            }



        }

        public DataTable FinlizeWrk(DateTime FnlDt, int type)
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"FinDt",FnlDt},
                   {"typ",type}
            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("FinalDate", objDIc);
            }


        }

        public DataSet GetDash()
        {
            {
                var objDIc = new Dictionary<string, object>();

                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("Dashboard", objDIc);
            }



        }

        public DataTable GetReport(DateTime FrmDt, DateTime ToDt)
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"Dtfrom",FrmDt},
                   {"ToDt",ToDt}
            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("WorkHourReport", objDIc);
            }


        }

        public DataTable SaveWorkersLine()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"Plant_Id",plant_Id},
                   {"SectionId",sec_Id},
                   {"sub_sec_Id",sub_sec_Id},
                   {"Smo",smo},
                   {"hours",Whours},
                   {"typ",type},
                   {"braek",braekTime},
                   {"start_time",frmTime},
                  {"end_time",toTime},

            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("LineWrkcount", objDIc);
            }

        }

        public DataTable GetWorkcont()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT [Idx], [Plant_Id],[plant_name] ,[SectionId],[section_name],[sub_sec_name] ,[Smo],[entertime],[CreatedDate],[IsActive],[hours],[braekTime],[wrkMin],[start_time],[end_time] FROM [dbo].[VIEW_getWrkCnt] where CONVERT(date, [CreatedDate]) = CONVERT(date,[dbo].[GetSLCurrTime] ())");
        }

        //public DataTable GetWrkCnt()
        //{
        //    return (new DbAccess(Connection)).FillDataTable("SELECT [hourPeriod],[WrkMin], 0 as breakTime , 0 as smo FROM [dbo].[prdctn_lineby_worker_count_timePeriod] order by [hourPeriod]");
        //}

        public DataSet GetWorkersCnt()
        {
            {
                var objDIc = new Dictionary<string, object>();

                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("GetLineWise", objDIc);
            }


        }
        public DataTable Getworkcnt()
        {
            {
                var objDIc = new Dictionary<string, object> {

                  {"plant_Id",plant_Id },
                  {"SectionId",sec_Id},
                  {"sub_section_Id",sub_sec_Id}

            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SelectHoursCnt", objDIc);
            }


        }

        public DataTable SearchwrkList(int SubId)
        {
            //var obj = new Dictionary<string, object>
            {
                var objDIc = new Dictionary<string, object> {

                   {"sub_section",SubId}

            };
                var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("GetSearch", objDIc);
                return dt;
            }

        }
        
        public DataTable SearchOrdList(int po_no)
        {
            //var obj = new Dictionary<string, object>
            {
                var objDIc = new Dictionary<string, object> {

                   {"po_no",po_no}

            };
                var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaerchOrderNo", objDIc);
                return dt;
            }

        }

        public DataSet GetDashEffe()
        {
            {
                var objDIc = new Dictionary<string, object>();

                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("EffiDashboard", objDIc);
            }


        }
        public DataTable ProfileUpload()
        {
            //var obj = new Dictionary<string, object>
            {
                var objDIc = new Dictionary<string, object> {

                   {"plant_Id",plant_Id},
                   {"sec_Id",sec_Id},
                   {"sub_sec_Id",sub_sec_Id},
                   {"Img",Img},
                   {"id",id},
                   {"type",type},

            };
                var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Save_Line_Prod_Profile", objDIc);
                return dt;
            }

        }
        public DataTable GetProdProfile()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT [Id],[plantId] ,[plant_name],[sec_Id],[section_name],[sub_sec_Id] ,[sub_sec_name] ,[Img] FROM [dbo].[VIEW_Production_Profile]");
        }
        //public DataTable DeleteProf()
        //{
        //    {
        //        var objDIc = new Dictionary<string, object> {

        //           {"plant_Id",plant_Id},
        //           {"sec_Id",sec_Id},
        //           {"sub_sec_Id",sub_sec_Id},
        //           {"Img",Img},
        //           {"id",id},
        //           {"type",type},

        //    };
        //        var dt = (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Save_Line_Prod_Profile", objDIc);
        //        return dt;
        //    }


        //}
        //------------------------END-------------------
    }
}