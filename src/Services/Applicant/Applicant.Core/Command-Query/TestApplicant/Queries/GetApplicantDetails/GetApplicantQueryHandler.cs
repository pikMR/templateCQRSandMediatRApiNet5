using System.Security;
using AutoMapper;
using MediatR;
using Applicant.Core.Contracts.Persistance;
using Applicant.Core.Exceptions;
using Applicant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Core.Command_Query.TestApplicant.Queries.GetApplicantDetails
{
    public class GetApplicantQueryHandler : IRequestHandler<GetApplicantDetailsQuery, TestApplicantVm>
    {
        private readonly IAsyncRepository<Applicant.Domain.Entities.TestApplicant> _testApplicantRepo;
        private readonly IAsyncRepository<TestInfo> _testInfoRepo;
        private readonly IMapper _mapper;

        public GetApplicantQueryHandler
            (IAsyncRepository<Applicant.Domain.Entities.TestApplicant> testApplicantRepo,
            IAsyncRepository<TestInfo> testInfoRepo,
            IMapper mapper)
        {
            _testApplicantRepo = testApplicantRepo;
            _testInfoRepo = testInfoRepo;
            _mapper = mapper;
        }


        public async Task<TestApplicantVm> Handle(GetApplicantDetailsQuery request, CancellationToken cancellationToken)
        {
            var testApplicantEntity = await _testApplicantRepo.GetByIdAsync(request.ID);


            if (testApplicantEntity == null)
                throw new ModelNotFoundException
                     (nameof(Applicant.Domain.Entities.TestApplicant), request.ID);

            if (request.IncludeTestInfor)
            {
                var testInfo = await _testInfoRepo.GetByIdAsync(testApplicantEntity.TestInfoID);

                testApplicantEntity.TestInfo = testInfo;
            }

            return _mapper.Map<TestApplicantVm>(testApplicantEntity);
        }
    }
}
