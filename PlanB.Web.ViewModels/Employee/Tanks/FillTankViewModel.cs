﻿using PlanB.Data.Models;
using PlanB.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanB.Web.ViewModels.Employee.Tanks
{
    public class FillTankViewModel : IMapFrom<Tank>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; } 

        public double RoundAmount => Math.Round(Amount, 2);
    }
}
