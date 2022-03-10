﻿using Ganss.XSS;
using PlanB.Data.Models;
using PlanB.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Home
{
    public class TopBarMassageViewModel : IMapFrom<Massage>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string ShortContent 
        {
            get { return this.SanitizedContent.Substring(0, 10) + "..."; }

            set
            {
                if (value.Length < 10)
                {
                    new HtmlSanitizer().Sanitize(this.Content);
                }
            }
        }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string FullName => this.UserFirstName + " " + this.UserLastName;

        public DateTime CreatedOn { get; set; }
    }
}
