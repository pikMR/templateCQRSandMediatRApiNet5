namespace Applicant.Domain.Entities
{
    using System;
    using Applicant.Domain.Shared;
    public class TestApplicant : ModifiableEntity
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int TestInfoID { get; set; }

        public TestInfo TestInfo { get; set; }
    }
}