using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class EditorMenu : MonoBehaviour
{
    [MenuItem("TestMenu/01_Scence/Main")]
    static void EditorMenu_LoadInGameScene()
    {
        EditorSceneManager.OpenScene("Assets/01_Scene/MainMenu.unity");
    }

    [MenuItem("TestMenu/01_Scence/Second")]
    static void EditorMenu_LoadSecondScene()
    {
        EditorSceneManager.OpenScene("Assets/01_Scene/Reflection.unity");
    }
}
