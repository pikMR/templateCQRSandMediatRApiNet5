using AutoMapper;
using MediatR;
using Applicant.Core.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Core.Command_Query.TestApplicant.Queries.GetApplicantList
{
    public class GetApplicantListQueryHandler : IRequestHandler<GetApplicantListQuery, List<TestApplicantListVm>>
    {
        private readonly IAsyncRepository<Applicant.Domain.Entities.TestApplicant> _testApplicantRepo;
        private readonly IMapper _mapper;

        public GetApplicantListQueryHandler
            (IAsyncRepository<Applicant.Domain.Entities.TestApplicant> testApplicantRepo,
            IMapper mapper)
        {
            _testApplicantRepo = testApplicantRepo;
            _mapper = mapper;
        }


        public async Task<List<TestApplicantListVm>> Handle
            (GetApplicantListQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<TestApplicantListVm>>(await _testApplicantRepo.ListAllAsync());
        }
    }
}
