using AutoMapper;
using MediatR;
using Applicant.Core.Contracts.Persistance;
using Applicant.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Core.Command_Query.TestApplicant.Commands.UpdateApplicant
{
    public class UpdateApplicantHandler : IRequestHandler<UpdateApplicantCommand, Unit>
    {
        private readonly IAsyncRepository<Applicant.Domain.Entities.TestApplicant> _testApplicantRepo;
        private readonly IMapper _mapper;


        public UpdateApplicantHandler
            (IAsyncRepository<Applicant.Domain.Entities.TestApplicant> testApplicantRepo,
            IMapper mapper)
        {
            _testApplicantRepo = testApplicantRepo;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var updateApplicantValidator = new UpdateApplicantValidator();

            var validationResult = await updateApplicantValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new ModelValidationException(validationResult);

            var applicantEntity = _mapper.Map <Applicant.Domain.Entities.TestApplicant> (request);

            await _testApplicantRepo.UpdateAsync(applicantEntity);

            return Unit.Value;
        }
    }
}
