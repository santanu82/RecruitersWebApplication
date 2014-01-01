using RecruitersWebApplication.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace RecruitersWebApplication.Models.Interfaces
{
    public interface IRecruitersRepository
    {
        void GetAdvancedFilteredRecruiterDetails(string companyName, string companySpecialists, string categoryType, string officeLocation, GridView gridView);

        void GetFilteredRecruiterDetails(string companyName, GridView gridView);

        List<string> GetRecruiterNames(string searchText);

        void GetCompanySpecialists(DropDownList ddlCompanySpecialists);

        void GetCategoryType(DropDownList ddlCategoryType);

        void GetOfficeLocation(DropDownList ddlOfficeLocation);
    }
}
