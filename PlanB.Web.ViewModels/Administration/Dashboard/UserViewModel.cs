using AutoMapper;
using PlanB.Data.Models;
using PlanB.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Administration.Dashboard
{
    public class UserViewModel 
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string PhomeNumber { get; set; }

        public ICollection<RoleViewModel> Roles{ get; set;}
    }
}
