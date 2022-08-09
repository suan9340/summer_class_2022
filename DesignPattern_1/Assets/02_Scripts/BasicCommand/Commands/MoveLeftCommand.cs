using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class MoveLeftCommand : Command
    {
        private MoveObject moveObject;

        public MoveLeftCommand(MoveObject _moveObject)
        {
            this.moveObject = _moveObject;
        }

        public override void Execute()
        {
            moveObject.TurnLeft();
        }

        public override void Undo()
        {
            moveObject.TurnRight();
        }
    }
}
