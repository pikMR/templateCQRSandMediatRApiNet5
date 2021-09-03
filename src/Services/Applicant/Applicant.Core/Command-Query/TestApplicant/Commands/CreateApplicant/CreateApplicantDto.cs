﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Applicant.Core.Command_Query.TestApplicant.Commands.CreateApplicant
{
    public class CreateApplicantDto
    {
        public int ID { get; set; }
     
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TestInfoID { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
