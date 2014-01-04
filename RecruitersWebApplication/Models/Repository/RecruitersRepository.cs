using RecruitersWebApplication.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RecruitersWebApplication.Models.Repository
{
    public class RecruitersRepository : IRecruitersRepository
    {
        /// <summary>
        /// This method returns recruiter's details based on company name, company specialists, category type and office location
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="companySpecialists"></param>
        /// <param name="categoryType"></param>
        /// <param name="officeLocation"></param>
        /// <param name="gridView">GridView to bind</param>
        public void GetAdvancedFilteredRecruiterDetails(string companyName, string companySpecialists, string categoryType, string officeLocation, GridView gridView)
        {
            Recruiter recruiter = new Recruiter();
            recruiter.CompanyName = companyName;
            recruiter.CompanySpecialists = companySpecialists;
            recruiter.CategoryType = categoryType;
            recruiter.OfficeLocation = officeLocation;

            using (RecruitersDBDataContext db = new RecruitersDBDataContext())
            {
                var recruitersInfoAdvanced = db.Recruiters.Select(r => new Recruiter
                {
                    CompanyName = r.CompanyName,
                    CompanyWebsite = r.CompanyWebsite,
                    CompanySize = r.CompanySize,
                    CompanyLinkedInUrl = r.CompanyLinkedInUrl,
                    CompanyLinkedInId = r.CompanyLinkedInId,
                    CompanySpecialists = r.CompanySpecialists,
                    CategoryType = r.CategoryType,
                    OfficeLocation = r.OfficeLocation,
                    ContactNumber = r.ContactNumber,
                    ContactEmail = r.ContactEmail,
                    TwitterId = r.TwitterId
                }).Where(r => r.CompanyName == recruiter.CompanyName || r.CompanySpecialists == recruiter.CompanySpecialists
                                                     || r.CategoryType == recruiter.CategoryType || r.OfficeLocation == recruiter.OfficeLocation).AsEnumerable();

                gridView.DataSource = recruitersInfoAdvanced;

                gridView.DataBind();
            }



        }
        /// <summary>
        /// This method returns the recruiter's details based on company name
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="gridView"></param>
        public void GetFilteredRecruiterDetails(string companyName, GridView gridView)
        {
            Recruiter recruiter = new Recruiter();
            recruiter.CompanyName = companyName;
            using (RecruitersDBDataContext db = new RecruitersDBDataContext())
            {
                var recruitersInfo = db.Recruiters.Select(r => new Recruiter
                {
                    CompanyName = r.CompanyName,
                    CompanyWebsite = r.CompanyWebsite,
                    CompanySize = r.CompanySize,
                    CompanyLinkedInUrl = r.CompanyLinkedInUrl,
                    CompanyLinkedInId = r.CompanyLinkedInId,
                    CompanySpecialists = r.CompanySpecialists,
                    CategoryType = r.CategoryType,
                    OfficeLocation = r.OfficeLocation,
                    ContactNumber = r.ContactNumber,
                    ContactEmail = r.ContactEmail,
                    TwitterId = r.TwitterId
                }).Where(r => r.CompanyName == recruiter.CompanyName).AsEnumerable();

                gridView.DataSource = recruitersInfo;

                gridView.DataBind();
            }


        }
        /// <summary>
        /// This method returns list of recruiter names based on the search text typed in the textbox.
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<string> GetRecruiterNames(string searchText)
        {
            using (RecruitersDBDataContext db = new RecruitersDBDataContext())
            {
                var recruiterNames = (from r in db.Recruiters
                                      where r.CompanyName.Contains(searchText)
                                      select r.CompanyName).ToList();

                return recruiterNames;
            }
           

        }
       /// <summary>
        /// This method returns list of all distinct Company Specialist and bind to the corresponding drop down list
       /// </summary>
       /// <param name="ddlCompanySpecialists">DropDownList to bind</param>
        public void GetCompanySpecialists(DropDownList ddlCompanySpecialists)
        {
            using (RecruitersDBDataContext db = new RecruitersDBDataContext())
            {
                var companySpecialistsList = (from r in db.Recruiters
                                              select r.CompanySpecialists).Distinct().ToList();

                ddlCompanySpecialists.DataSource = companySpecialistsList;
                ddlCompanySpecialists.DataBind();
                ddlCompanySpecialists.Items.Insert(0, new ListItem("-Select your choice-", ""));
            }
           

        }
        /// <summary>
        /// This method returns list of all distinct Category Type and bind to the corresponding drop down list
        /// </summary>
        /// <param name="ddlCategoryType">DropDownList to bind</param>
        public void GetCategoryType(DropDownList ddlCategoryType)
        {
            using (RecruitersDBDataContext db = new RecruitersDBDataContext())
            {
                var categoryTypeList = (from r in db.Recruiters
                                        select r.CategoryType).Distinct().ToList();

                ddlCategoryType.DataSource = categoryTypeList;
                ddlCategoryType.DataBind();
                ddlCategoryType.Items.Insert(0, new ListItem("-Select your choice-", ""));
            }
            

        }
        /// <summary>
        /// This method returns list of all distinct Office Location and bind to the corresponding drop down list
        /// </summary>
        /// <param name="ddlOfficeLocation">DropDownList to bind</param>
        public void GetOfficeLocation(DropDownList ddlOfficeLocation)
        {
            using (RecruitersDBDataContext db = new RecruitersDBDataContext())
            {
                var officeLocationList = (from r in db.Recruiters
                                          select r.OfficeLocation).Distinct().ToList();

                ddlOfficeLocation.DataSource = officeLocationList;
                ddlOfficeLocation.DataBind();
                ddlOfficeLocation.Items.Insert(0, new ListItem("-Select your choice-", ""));
            }
            

        }




    }
}