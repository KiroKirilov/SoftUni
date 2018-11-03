using SIS.Framework.Security.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Framework.Attributes.Action
{
    public class AuthorizeAttribute : Attribute
    {
        private readonly string role;

        public AuthorizeAttribute() { }

        public AuthorizeAttribute(string role)
        {
            this.role = role;
        }

        private bool IsIdentityPresent(IIdentity identity)
        {
            return identity != null;
        }

        private bool IsIdentityInRole(IIdentity identity)
        {
            if (this.IsIdentityPresent(identity))
            {
                return identity.Roles.Contains(this.role);
            }

            return false;
        }

        public bool IsAuthrised(IIdentity user)
        {
            if (this.role==null)
            {
                return this.IsIdentityPresent(user);
            }
            else
            {
                return this.IsIdentityInRole(user);
            }
        }
    }
}
