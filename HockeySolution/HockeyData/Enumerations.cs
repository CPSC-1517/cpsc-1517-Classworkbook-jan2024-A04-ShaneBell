using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Data
{
    public enum Role
    {
        Coach,
        Player,
        Trainer,
        Other
    }
    public enum Position
    {
        //By default the values start at 0
        LeftWing = 1,//can explicitly set the values
        RightWing,
        Center,
        Defense,
        Goalie
    }
    public enum Shot
    {
        Left,
        Right
    }

}

