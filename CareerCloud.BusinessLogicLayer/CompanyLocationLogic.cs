using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
        { }
        public override void Update(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public override void Add(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        protected override void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyLocationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CountryCode))
                {
                    exceptions.Add(new ValidationException(500, "Value is empty."));
                }
                if (string.IsNullOrEmpty(poco.Province))
                {
                    exceptions.Add(new ValidationException(501, "Value is empty."));
                }
                if (string.IsNullOrEmpty(poco.Street))
                {
                    exceptions.Add(new ValidationException(502, "Value is empty."));
                }
                if (string.IsNullOrEmpty(poco.City))
                {
                    exceptions.Add(new ValidationException(503, "Value is empty."));
                }
                if (string.IsNullOrEmpty(poco.PostalCode))
                {
                    exceptions.Add(new ValidationException(504, "Value is empty."));
                }

            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
