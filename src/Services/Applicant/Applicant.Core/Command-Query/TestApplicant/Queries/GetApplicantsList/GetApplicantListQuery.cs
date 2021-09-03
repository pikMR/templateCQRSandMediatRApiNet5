using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicant.Core.Command_Query.TestApplicant.Queries.GetApplicantList
{
    public class GetApplicantListQuery : IRequest<List<TestApplicantListVm>>
    {

    }
}
