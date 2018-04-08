using System;
using System.Collections.Generic;
using System.Text;

public class CustomJobCollection : List<Job>
{
    public void OnJobDone(object sender, JobEventArgs e)
    {
        this.Remove(e.Job);
    }
}
