﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.Attributes.HttpMethod
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "POST")
            {
                return true;
            }

            return false;
        }
    }
}
