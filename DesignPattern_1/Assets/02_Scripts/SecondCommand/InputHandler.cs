using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject playerObj = null;

    private Animator anim = null;

    private Commands keyQ, keyW, keyE, upArrow;

    private Stack<Commands> undoCommand = new Stack<Commands>();

    private bool isReplay = false;

    private void Start()
    {
        anim = playerObj.GetComponent<Animator>();

        keyQ = new PerformJump();
        keyW = new PerformKick();
        keyE = new PerformPunch();
        upArrow = new MoveForward();

        Camera.main.GetComponent<CameraFollow360>().player = playerObj.transform;
    }

    private void Update()
    {
        if (!isReplay)
            HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Excute(keyQ);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Excute(keyW);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Excute(keyE);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Excute(upArrow);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Undo();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Replay());
        }
    }

    private void Excute(Commands _button)
    {
        _button.Execute(anim, true);
        undoCommand.Push(_button);
    }

    private void Undo()
    {
        if (undoCommand.Count == 0)
        {
            Debug.LogWarning("UNDO NULL!!");
        }
        else
        {
            Debug.Log("UNDO");
            var _lastCommand = undoCommand.Pop();
            _lastCommand.Undo(anim);
        }
    }

    private IEnumerator Replay()
    {
        if (isReplay && undoCommand.Count > 0) yield break;

        isReplay = true;

        Debug.Log("Replay Start!!");

        Commands[] _oldCommand = undoCommand.ToArray();

        for (int i = _oldCommand.Length - 1; i >= 0; i--)
        {
            var _curCommand = _oldCommand[i];

            _curCommand.Execute(anim, false);

            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Replay End!!");
        isReplay = false;
        yield break;
    }

}
