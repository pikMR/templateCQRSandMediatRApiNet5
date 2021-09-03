using System;
using System.Collections.Generic;
using System.Text;

namespace Applicant.Core.Exceptions
{
    public class ModelNotFoundException : ApplicationException
    {
        public ModelNotFoundException(string name, object key)
                : base($"{name} ({key}) is not found")
        {

        }


    }
}
