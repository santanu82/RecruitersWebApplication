using RecruitersWebApplication.Models;
using RecruitersWebApplication.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace RecruitersWebApplication
{
    /// <summary>
    /// Summary description for RecruiterService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class RecruiterService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetRecruiterNames(string searchText)
        {
            RecruitersRepository recruitersRepository = new RecruitersRepository();
            return recruitersRepository.GetRecruiterNames(searchText);
            

        }
    }
}
