using AutoMapper;
using Applicant.Core.Command_Query.TestApplicant.Commands.CreateApplicant;
using Applicant.Core.Command_Query.TestApplicant.Commands.UpdateApplicant;
using Applicant.Core.Command_Query.TestApplicant.Queries.GetApplicantDetails;
using Applicant.Core.Command_Query.TestApplicant.Queries.GetApplicantList;
using System;
using System.Collections.Generic;
using System.Text;
using Applicant.Domain.Entities;

namespace Applicant.Core.MappingProfile
{
    public class ModelsMapper : Profile
    {
        public ModelsMapper()
        {
            CreateMap<TestApplicant, CreateApplicantDto>().ReverseMap();
            CreateMap<TestApplicant, CreateApplicantCommand>().ReverseMap();
            CreateMap<TestApplicant, UpdateApplicantCommand>().ReverseMap();
            CreateMap<TestApplicant, TestApplicantVm>().ReverseMap();
            CreateMap<TestApplicant, TestApplicantListVm>().ReverseMap();
            CreateMap<TestInfo, TestInfoDto>().ReverseMap();
        }
    }
}
