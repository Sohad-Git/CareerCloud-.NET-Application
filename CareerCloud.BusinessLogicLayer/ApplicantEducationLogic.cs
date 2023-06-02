using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {}
        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach(ApplicantEducationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(107, "Value is empty."));
                }
                else if (poco.Major.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, "Can not be less than 3."));
                }
                if(poco.StartDate > DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108, "Date is out of range."));
                }
                if(poco.StartDate > poco.CompletionDate)
                {
                    exceptions.Add(new ValidationException(109, "Wrong Input."));
                }
            }
            if(exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
