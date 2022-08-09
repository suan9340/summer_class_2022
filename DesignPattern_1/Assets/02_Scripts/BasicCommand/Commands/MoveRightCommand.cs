using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class MoveRightCommand : Command
    {
        private MoveObject moveObject;

        public MoveRightCommand(MoveObject _moveObject)
        {
            this.moveObject = _moveObject;
        }

        public override void Execute()
        {
            moveObject.TurnRight();
        }

        public override void Undo()
        {
            moveObject.TurnLeft();
        }
    }
}
