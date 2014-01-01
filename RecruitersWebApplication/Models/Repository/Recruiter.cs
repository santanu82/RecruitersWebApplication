using RecruitersWebApplication.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitersWebApplication.Models.Repository
{
    public class Recruiter 
    {


        //public int CompanyID
        //{
        //    get;
        //    set;
        //}

        public string CompanyName
        {
            get;
            set;
        }

        public string CompanyWebsite
        {
            get;
            set;
        }

        public string CompanySize
        {
            get;
            set;
        }

        public string CompanyLinkedInUrl
        {
            get;
            set;
        }

        public int CompanyLinkedInId
        {
            get;
            set;
        }

        public string CompanySpecialists
        {
            get;
            set;
        }

        public string CategoryType
        {
            get;
            set;
        }

        public string OfficeLocation
        {
            get;
            set;
        }

        public string ContactNumber
        {
            get;
            set;
        }

        public string ContactEmail
        {
            get;
            set;
        }

        public string TwitterId
        {
            get;
            set;
        }
    }
}