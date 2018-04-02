using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Attributes
{
    [AttributeUsage(AttributeTargets.Field,AllowMultiple =true)]
    public class InjectAttribute : Attribute
    {
    }
}
