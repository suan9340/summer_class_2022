using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class MoveFowardCommand : Command
    {
        private MoveObject moveObject;

        public MoveFowardCommand(MoveObject _moveObject)
        {
            this.moveObject = _moveObject;
        }

        public override void Execute()
        {
            moveObject.MoveFoward();
        }

        public override void Undo()
        {
            moveObject.MoveBack();
        }
    }
}
