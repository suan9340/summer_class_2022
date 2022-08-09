using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public abstract class Command
    {
        public abstract void Execute();     // �����ϰ�
            
        public abstract void Undo();        // �ǵ�����
    }

}
