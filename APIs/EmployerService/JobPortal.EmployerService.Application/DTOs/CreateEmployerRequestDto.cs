﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.EmployerService.Application.DTOs
{
    public class CreateEmployerRequestDto
    {
        public Guid IdentityRefId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
    }
}
