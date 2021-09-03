using MediatR;
using Applicant.Core.Contracts.Persistance;
using Applicant.Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Core.Command_Query.TestApplicant.Commands.DeleteApplicant
{
    public class DeleteApplicantHandler : IRequestHandler<DeleteApplicantCommand, Unit>
    {

        private readonly IAsyncRepository<Applicant.Domain.Entities.TestApplicant> _testApplicantRepo;

        public DeleteApplicantHandler
            (IAsyncRepository<Applicant.Domain.Entities.TestApplicant> testApplicantRepo)
        {
            _testApplicantRepo = testApplicantRepo;
        }

        public async Task<Unit> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var testApplicantEntity = await _testApplicantRepo.GetByIdAsync(request.TestApplicantID);

            if (testApplicantEntity == null)
                throw new ModelNotFoundException
                    (nameof(Applicant.Domain.Entities.TestApplicant),request.TestApplicantID);


            await _testApplicantRepo.DeleteAsync(testApplicantEntity);

            return Unit.Value;
        }
    }
}
