using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class DoNothingCommand : Command
    {
        public override void Execute()
        {

        }

        public override void Undo()
        {
                                    
        }
    }
}

