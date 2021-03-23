using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductionPrint.models;

namespace ProductionPrint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkHoursApiController : ControllerBase
    {

        [HttpGet("getDash")]
        public DataSet GetDash()
        {
           WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetDash();
        }
        [HttpGet("getDashDateBy")]
        public DataSet GetDashDateBy()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetDashDate();
        }


        [HttpPost("getSection")]
        public DataTable GetSection(ClsPrm prm)
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetSection(prm.iPram1);
        }

        [HttpPost("getSubSection")]
        public DataTable GetSubSection(ClsPrm prm)
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetSubSection(prm.iPram1, prm.iPram2);
        }

        [HttpGet("getSubSectionBy")]
        public DataTable GetSubSectionBy()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetSubSectionBy();
        }
        //LoadOrderList
        [HttpGet("getOrders")]
        public DataTable GetOrders()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.LoadOrderList();
        }
        //GetWorkHours
        [HttpGet("getWorkHours")]
        public DataTable GetWorkHours()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetWorkHours();
        }
        [HttpPost("saveWorkHours")]
        public DataTable SaveWorkHours(WorkHours wrk)
        {
           // WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.SaveWork();
        }

        [HttpPost("finaliz")]
        public DataTable Finaliz(ClsPrm prm)
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.FinlizeWrk(prm.DtPram1,prm.iPram1);
        }

        [HttpPost("getWorkReport")]
        public DataTable GetWorkReport(ClsPrm prm)
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetReport(prm.DtPram1, prm.DtPram2);
        }

        [HttpPost("saveworkesline")]
        public DataTable Saveworkesline(WorkHours wrk)
        {
           // WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.SaveWorkersLine();
        }

        [HttpGet("getWorkersCount")]
        public DataTable GetWorkersCount()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetWorkcont();
        }

        //[HttpGet("getWorkCnt")]
        //public DataTable GetWorkCnt()
        //{
        //    WorkHours wrk = new WorkHours(CommonData.ConStr());
        //    return wrk.GetWrkCnt();
        //}

       // Getworkcnt
        [HttpPost("getWrkCnt")]
        public DataTable getWrkCnt(WorkHours wrk)
        {
            //WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.Getworkcnt();
        }

        [HttpGet("getWorker")]
        public DataSet GetWorker()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetWorkersCnt();
        }


        [HttpGet("getWorkhouly")]
        public DataSet getWorkhouly()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetWorkersCnt();
        }

        [HttpPost("getDetailsworkSearch")]
        public DataTable GetDetailsworkSearch(ClsPrm prm)
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.SearchwrkList(prm.iPram1);
        }


        [HttpPost("getSearchOrdList")]
        public DataTable GetSearchOrdList(ClsPrm prm)
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.SearchOrdList(prm.iPram1);
        }
        [HttpPost("deletwrk")]
        public DataTable Deletwrk(ClsPrm prm)
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.DeleteWorkHours(prm.gPram1);
        }

        [HttpPost("deletSwprd")]
        public DataTable DeletSwprd(ClsPrm prm)
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.DeleteSweingPrd(prm.iPram1);
        }

        [HttpPost("getTotalQnty")]
        public DataTable GetTotalQnty(ClsPrm prm)
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.TotalQuantity(prm.iPram1,prm.iPram2);
        }

        [HttpGet("dashEff")]
        public DataSet DashEff()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetDashEffe();
        }

        [HttpPost("saveworkeslineProfile")]
        public DataTable SaveworkeslineProfile(WorkHours wrk)
        {
            // WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.ProfileUpload();
        }
        //
        [HttpGet("getProdProfile")]
        public DataTable GetProdProfile()
        {
            WorkHours wrk = new WorkHours(CommonData.ConStr());
            return wrk.GetProdProfile();
        }

        //---------------PO Change Qnty
        //ChangeQnty
        [HttpPost("changePOQnty")]
        public DataTable ChangePOQnty(QntyChange qnyChng)
        {
            // WorkHours wrk = new WorkHours(CommonData.ConStr());
            return qnyChng.ChangeQnty();
        }
    }
}