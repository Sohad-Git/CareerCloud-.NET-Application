﻿using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantJobApplicationController : ControllerBase
    {
        private readonly ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationController()
        {
            var repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("jobapplication/{id}")]
        public ActionResult GetApplicantJobApplication(Guid id)
        {
            ApplicantJobApplicationPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpGet]
        [Route("jobapplication")]
        public ActionResult GetAllApplicantJobApplication()
        {
            var applicants = _logic.GetAll();
            if (applicants == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(applicants);
            }
        }

        [HttpPost]
        [Route("jobapplication")]
        public ActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] poco)
        {
            _logic.Add(poco);
            return Ok();
        }

        [HttpPut]
        [Route("jobapplication")]
        public ActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] poco)
        {
            _logic.Update(poco);
            return Ok();
        }

        [HttpDelete]
        [Route("jobapplication")]
        public ActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] poco)
        {
            _logic.Delete(poco);
            return Ok();
        }
    }
}
