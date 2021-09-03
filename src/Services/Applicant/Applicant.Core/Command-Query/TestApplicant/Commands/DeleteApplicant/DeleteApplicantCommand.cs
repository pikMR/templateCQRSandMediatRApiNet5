﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicant.Core.Command_Query.TestApplicant.Commands.DeleteApplicant
{
    public class DeleteApplicantCommand : IRequest
    {
        public int TestApplicantID { get; set; }
    }
}
