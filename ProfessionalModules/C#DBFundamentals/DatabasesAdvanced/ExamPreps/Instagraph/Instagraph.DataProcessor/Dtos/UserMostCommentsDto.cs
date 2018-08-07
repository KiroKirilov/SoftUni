using System;
using System.Collections.Generic;
using System.Text;

namespace Instagraph.DataProcessor.Dtos
{
    public class UserMostCommentsDto
    {
        public string Username { get; set; }

        public int MostComments { get; set; }
    }
}
