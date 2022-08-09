using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern.RebindKeys
{
    public class GameController : MonoBehaviour
    {
        public MoveObject moveObj = null;

        private Command buttonW;
        private Command buttonA;
        private Command buttonS;
        private Command buttonD;

        private Stack<Command> undoCommand = new Stack<Command>();
        private Stack<Command> redoCommand = new Stack<Command>();

        private bool isReplaying = false;
        private Vector3 startPos = Vector3.zero;
        private const float REPLAY_PUASE_TIME = 0.5f;

        private void Start()
        {
            buttonW = new MoveFowardCommand(moveObj);
            buttonA = new MoveLeftCommand(moveObj);
            buttonS = new MoveBackCommand(moveObj);
            buttonD = new MoveRightCommand(moveObj);

            startPos = moveObj.transform.position;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                Undo();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Redo();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(Replay());
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                ExecuteNewCommand(buttonW);
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                ExecuteNewCommand(buttonA);
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                ExecuteNewCommand(buttonS);
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                ExecuteNewCommand(buttonD);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Å° ½º¿Ò");
                SwapKeys(ref buttonW, ref buttonS);
            }
        }

        private void ExecuteNewCommand(Command _commandBtn)
        {
            _commandBtn.Execute();
            undoCommand.Push(_commandBtn);

            redoCommand.Clear();
        }

        private void SwapKeys(ref Command _key1, ref Command _key2)
        {
            var _tmp = _key1;
            _key1 = _key2;
            _key2 = _tmp;
        }

        private void Undo()
        {
            if (undoCommand.Count == 0)
            {
                Debug.Log("NO UNDO");
            }
            else
            {
                Debug.Log("UNDO");
                var _lastCommand = undoCommand.Pop();
                _lastCommand.Undo();
                redoCommand.Push(_lastCommand);
            }
        }

        private void Redo()
        {
            if (redoCommand.Count == 0)
            {
                Debug.Log("NO REDO");
            }
            else
            {
                var _nextCommand = redoCommand.Pop();
                _nextCommand.Execute();
                undoCommand.Push(_nextCommand);
            }
        }

        private IEnumerator Replay()
        {
            if (isReplaying) yield break;

            Debug.Log("START REPLAY");

            isReplaying = true;

            moveObj.transform.position = startPos;

            yield return new WaitForSeconds(REPLAY_PUASE_TIME);

            Command[] _oldCommand = undoCommand.ToArray();

            for (int i = _oldCommand.Length - 1; i >= 0; i--)
            {
                var _curCommand = _oldCommand[i];

                _curCommand.Execute();

                yield return new WaitForSeconds(REPLAY_PUASE_TIME);
            }

            Debug.Log("END REPLAY");
            isReplaying = false;
        }
    }
}

