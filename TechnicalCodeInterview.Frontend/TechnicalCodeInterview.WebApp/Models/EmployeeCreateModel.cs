﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalCodeInterview.DataLibrary.Models;

namespace TechnicalCodeInterview.WebApp.Models
{
    public class EmployeeCreateModel
    {
        public EmployeeModel Employee { get; set; } = new EmployeeModel();
    }
}
