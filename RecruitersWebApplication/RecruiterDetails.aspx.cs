using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecruitersWebApplication.Models;
using RecruitersWebApplication.Models.Interfaces;
using RecruitersWebApplication.Models.Repository;

namespace RecruitersWebApplication
{
    public partial class RecruiterDetails : System.Web.UI.Page
    {

        RecruitersRepository recruiterRepository = new RecruitersRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropDownListCompanySpecialists();
                BindDropDownListCategoryTypes();
                BindDropDownListOfficeLocation();
                
            }
           
        }
        protected override void OnInit(EventArgs e)
        {
            this.BindDropDownListCompanySpecialists();
            this.BindDropDownListCategoryTypes();
            this.BindDropDownListOfficeLocation();
            base.OnInit(e);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void BindGridView()
        {
            
            
            recruiterRepository.GetFilteredRecruiterDetails(tbCompanyName.Text,gvRecruiters);

        }
        private void BindGridViewAdvanced()
        {
            
            try
            {
                recruiterRepository.GetAdvancedFilteredRecruiterDetails(tbCompanyName.Text, ddlCompanySpecialists.SelectedItem.Text,
                                                                              ddlCategoryType.SelectedItem.Text, ddlOfficeLocation.SelectedItem.Text, gvRecruiters);
            }
            catch (Exception ex)
            {

                lbMsg.Text = ex.Message.ToString();
            }
          

           

          

            
        }
        private void BindDropDownListCompanySpecialists()
        {
            /* Please uncomment if you want directly use stored procedure from linq-to-sql class withouth using linq to sql code any repository.
            using (RecruitersDBDataContext db = new RecruitersDBDataContext())
            {
                var companySpecialistsList = db.sprocGetCompanySpecialists().ToList();
                List<string> companySpecialistsResult = new List<string>();
                foreach (var item in companySpecialistsList)
                {
                    companySpecialistsResult.Add(item.CompanySpecialists);
                }
                ddlCompanySpecialists.DataSource = companySpecialistsResult;
                ddlCompanySpecialists.DataBind();
                ddlCompanySpecialists.Items.Insert(0, new ListItem("-Select your choice-", ""));
            }
             * */
            recruiterRepository.GetCompanySpecialists(ddlCompanySpecialists);
        }
        private void BindDropDownListCategoryTypes()
        {
            /* Please uncomment if you want directly use stored procedure from linq-to-sql class withouth using linq to sql code any repository.
            using (RecruitersDBDataContext db = new RecruitersDBDataContext())
            {
                var categoryTypesList = db.sprocGetCategoryType().ToList();
                List<string> categoryTypesResult = new List<string>();
                foreach (var item in categoryTypesList)
                {
                    categoryTypesResult.Add(item.CategoryType);
                }
                ddlCategoryType.DataSource = categoryTypesResult;
                ddlCategoryType.DataBind();
                ddlCategoryType.Items.Insert(0, new ListItem("-Select your choice-", ""));
            }
             * */
            recruiterRepository.GetCategoryType(ddlCategoryType);
        }
        private void BindDropDownListOfficeLocation()
        {
            /*Please uncomment if you want directly use stored procedure from linq-to-sql class withouth using linq to sql code any repository.
            using (RecruitersDBDataContext db = new RecruitersDBDataContext())
            {
                var officeLocationList = db.sprocGetOfficeLocation().ToList();
                List<string> officeLocationResult = new List<string>();
                foreach (var item in officeLocationList)
                {
                    officeLocationResult.Add(item.OfficeLocation);
                }
                ddlOfficeLocation.DataSource = officeLocationResult;
                ddlOfficeLocation.DataBind();
                ddlOfficeLocation.Items.Insert(0, new ListItem("-Select your choice-", ""));
            }
             * */
            recruiterRepository.GetOfficeLocation(ddlOfficeLocation);
        }

        
        protected void ddlCompanySpecialists_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCompanySpecialists.SelectedItem.Selected.ToString();
            
            
        }

        protected void ddlCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCategoryType.SelectedItem.Selected.ToString();
            
        }

        protected void ddlOfficeLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOfficeLocation.SelectedItem.Selected.ToString();
            
        }

        protected void gvRecruiters_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRecruiters.PageIndex = e.NewPageIndex;
            BindGridView();
            BindGridViewAdvanced();
        }

        protected void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            
                BindGridViewAdvanced();
            
        }

       
     
    }
}