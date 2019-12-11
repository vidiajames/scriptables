
using UnityEditor;
using UnityEngine;

public class ClearPlayerPrefs : EditorWindow
{
    [MenuItem("Tools/Delete PlayerPrefs (All)")]
    static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
