﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.Attributes.HttpMethod
{
    public class HttpDeleteAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod.ToUpper() == "DELETE")
            {
                return true;
            }

            return false;
        }
    }
}
