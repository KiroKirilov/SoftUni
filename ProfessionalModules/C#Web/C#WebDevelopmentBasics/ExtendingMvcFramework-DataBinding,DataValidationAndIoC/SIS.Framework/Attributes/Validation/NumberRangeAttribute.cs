using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIS.Framework.Attributes.Validation
{
    public class NumberRangeAttribute : ValidationAttribute
    {
        private readonly double minValue;
        private readonly double maxValue;

        public NumberRangeAttribute(double minValue, double maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return (double)value >= this.minValue && (double)value <= this.maxValue;
        }
    }
}
