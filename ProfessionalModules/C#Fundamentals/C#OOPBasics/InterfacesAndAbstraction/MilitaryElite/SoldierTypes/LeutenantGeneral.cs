using System;
using System.Collections.Generic;
using System.Text;


public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public List<ISoldier> SoldiersUnderControl { get; private set; }

    public LeutenantGeneral(string id, string firstName, string lastName, double salary, List<ISoldier> soldiers)
        : base(id, firstName, lastName, salary)
    {
        this.SoldiersUnderControl = soldiers;
    }

    public override string ToString()
    {
        var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
        sb.AppendLine("Privates:");
        sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.SoldiersUnderControl)}");

        return sb.ToString().Trim();
    }
}

