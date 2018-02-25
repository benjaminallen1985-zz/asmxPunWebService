using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService.ASMX
{
    /// <summary>
    /// Summary description for PunService
    /// </summary>
    [WebService(Namespace = "http://puns.org/", Name="Pun Service v1.0", Description = "This web service provides create, read, update, and delete functions over a collection of Puns")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PunService : System.Web.Services.WebService
    {
        private PunDataService _service;

        public PunService()
        {
            _service = new PunDataService();
        }

        [WebMethod]
        public Pun[] GetPuns()
        {            
            return _service.GetPuns();
        }

        [WebMethod]
        public Pun GetPunByID(int punID)
        {
            return _service.GetPunById(punID);
        }

        [WebMethod]
        public void CreatePun(Pun pun)
        {
            _service.AddPun(pun);
        }

        [WebMethod]
        public void EditPun(Pun pun)
        {
            _service.UpdatePun(pun);
        }

        [WebMethod]
        public void DeletePun(int punID)
        {
            _service.DeletePun(punID);
        }
    }
}
