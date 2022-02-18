﻿using PlanB.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace PlanB.Data.Models
{
    public class Tank : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public double Amount { get; set; }
    }
}
