using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class MoveBackCommand : Command
    {
        private MoveObject moveObject;

        public MoveBackCommand(MoveObject _moveObject)
        {
            this.moveObject = _moveObject;
        }

        public override void Execute()
        {
            moveObject.MoveBack();
        }

        public override void Undo()
        {
            moveObject.MoveFoward();
        }
    }
}
