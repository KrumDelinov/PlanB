﻿using Ganss.XSS;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PlanB.Data.Models;
using PlanB.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Home
{
    public class MassageViewModel : IMapFrom<Massage>
    {
        public int Id { get; set; }
        
        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserName { get; set; }

        public IEnumerable<UserDropDownViewModel>?  Users { get; set; }
    }
}
