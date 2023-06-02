﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository) 
        { }
        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        protected override void Verify(ApplicantSkillPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(ApplicantSkillPoco poco in pocos)
            {
                if(poco.StartMonth > 12)
                {
                    exceptions.Add(new ValidationException(101, "Month most be less than 12."));
                }
                if(poco.EndMonth > 12)
                {
                    exceptions.Add(new ValidationException(102, "Month most be less than 12."));
                }
                if(poco.StartYear < 1900)
                {
                    exceptions.Add(new ValidationException(103, "How Old are you?!!(Value Can't be less than 1900)"));
                }
                if(poco.EndYear < poco.StartYear)
                {
                    exceptions.Add(new ValidationException(104, "Listen to your self!!.(Can't be before your Start Date.)"));
                }
            }
            if(exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
