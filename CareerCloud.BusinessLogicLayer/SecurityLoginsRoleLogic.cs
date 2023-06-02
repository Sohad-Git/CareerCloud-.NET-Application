using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
    {
        public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : base(repository)
        { }
        public override void Update(SecurityLoginsRolePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public override void Add(SecurityLoginsRolePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

    }
}
