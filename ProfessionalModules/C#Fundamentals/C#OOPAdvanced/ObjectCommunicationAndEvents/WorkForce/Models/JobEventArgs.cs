using System;
using System.Collections.Generic;
using System.Text;

public class JobEventArgs
{
    public JobEventArgs(Job job)
    {
        this.Job = job;
    }

    public Job Job { get; private set; }
}
