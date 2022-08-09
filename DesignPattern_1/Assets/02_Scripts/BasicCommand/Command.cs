using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public abstract class Command
    {
        public abstract void Execute();     // 실행하고
            
        public abstract void Undo();        // 되돌리다
    }

}
