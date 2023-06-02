using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobSkillLogic : BaseLogic<CompanyJobSkillPoco>
    {
        public CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository) : base(repository)
        { }
        public override void Update(CompanyJobSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public override void Add(CompanyJobSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        protected override void Verify(CompanyJobSkillPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyJobSkillPoco poco in pocos)
            {
                if (poco.Importance < 0)
                {
                    exceptions.Add(new ValidationException(400, "Value Can't be Negative."));
                }

            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
