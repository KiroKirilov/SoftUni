using SIS.Framework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Demo.ViewModels
{
    public class InputModel
    {
        [NumberRangeAttribute(1,10)]
        public double NumberInput { get; set; }
    }
}
