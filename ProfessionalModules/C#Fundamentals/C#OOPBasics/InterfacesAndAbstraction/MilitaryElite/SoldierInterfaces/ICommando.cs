using System;
using System.Collections.Generic;
using System.Text;


public interface ICommando
{
    List<IMission> Missions { get; }

    void CompleteMission();
}

