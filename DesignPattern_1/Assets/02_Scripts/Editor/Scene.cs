using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class Scene : MonoBehaviour
{
    [MenuItem("Scenes/Main_Scene")]
    static void EditorMenu_Main()
    {
        EditorSceneManager.OpenScene("Assets/01_Scenes/Main");
    }

    [MenuItem("Scenes/Main_CommandPattern")]
    static void EditorMenu_CommanPattern()
    {
        EditorSceneManager.OpenScene("Assets/01_Scenes/CharacterControlling");
    }
}
