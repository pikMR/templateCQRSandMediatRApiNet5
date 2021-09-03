using AutoMapper;
using MediatR;
using Applicant.Core.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Applicant.Core.Exceptions;

namespace Applicant.Core.Command_Query.TestApplicant.Commands.CreateApplicant
{
    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, CreateApplicantResponse>
    {
        private readonly IAsyncRepository<Applicant.Domain.Entities.TestApplicant> _testApplicantRepo;
        private readonly IMapper _mapper;

        public CreateApplicantCommandHandler
            (IAsyncRepository<Applicant.Domain.Entities.TestApplicant> testApplicantRepo,
            IMapper mapper)
        {
            _testApplicantRepo = testApplicantRepo;
            _mapper = mapper;
        }

        public async Task<CreateApplicantResponse> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            var createApplicantResponse = new CreateApplicantResponse();
            var createApplicantValidator = new CreateApplicantValidator();

            var validationResult = await createApplicantValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ModelValidationException(validationResult);

            var testApplicant = _mapper.Map<Applicant.Domain.Entities.TestApplicant>(request);

            createApplicantResponse.TestApplicant = _mapper.Map<CreateApplicantDto>(await _testApplicantRepo.AddAsync(testApplicant));


            return createApplicantResponse;
        }
    }
}
