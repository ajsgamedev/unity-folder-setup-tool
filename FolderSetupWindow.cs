// =============================================
// Folder Setup Tool
// © AJSGamedev 2026
// =============================================
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Editor window tool that generates a customisable folder 
/// structure in a new Unity project.
/// </summary>

public class FolderSetupWindow : EditorWindow
{
    // Dictionary used over two Lists to keep folder name and 
    // enabled state together and avoid index sync issues
    private Dictionary<string,bool> folders = new Dictionary<string, bool>
    {
        { "Animations", true },
        { "Audio",true },
        { "Fonts", true },
        { "Materials", true },
        { "Meshes", true },
        { "Prefabs", true },
        { "Scenes", true },
        { "Scripts", true },
        { "ScriptableObjects", true }, 
        { "Shaders", true },
        { "Sprites", true },
        { "Textures", true },
        { "ThirdParty", true },
        { "UI", true },
        { "_Sandbox", true } 
    };

    private Vector2 scrollPosition;

    [MenuItem("Tools/Folder Setup")]
    public static void OpenWindow()
    {
        FolderSetupWindow window = GetWindow<FolderSetupWindow>("Folder Setup");
        window.minSize = new Vector2(300, 400);
    }

    private void OnGUI()
    {
        GUILayout.Label("Project Folder Setup", EditorStyles.boldLabel);
        GUILayout.Space(5);
        GUILayout.Label("Add, remove or rename folders, then hit Generate.", EditorStyles.helpBox);
        GUILayout.Space(10);

        string folderToRemove = null;
        string keyToUpdate = null;
        bool valueToUpdate = false;

        string keyToRename = null;
        string newName = null;

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        //Loop to generate the GUI
        foreach (KeyValuePair<string,bool> folder in folders)
        {
            EditorGUILayout.BeginHorizontal();
            bool newValue = EditorGUILayout.Toggle(folder.Value, GUILayout.Width(20));
            string editedName = EditorGUILayout.TextField(folder.Key, GUILayout.ExpandWidth(true));
            
            if (editedName != folder.Key)
            {
                keyToRename = folder.Key;
                newName = editedName;
            }
            
            if (GUILayout.Button("X", GUILayout.Width(25)))
            {
                folderToRemove = folder.Key;
            }
            
            if (newValue != folder.Value)
            {
                keyToUpdate = folder.Key;
                valueToUpdate = newValue;
            }
            
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();

        GUILayout.Space(10);

        // Changes are stored and applied after the loop to avoid
        // modifying the dictionary during iteration
        if (folderToRemove != null)
        {
            folders.Remove(folderToRemove);
        }

        if (keyToUpdate != null)
        {
            folders[keyToUpdate] = valueToUpdate;
        }

        if (keyToRename != null)
        {
            bool currentValue = folders[keyToRename];
            folders.Remove(keyToRename);
            folders.Add(newName, currentValue);
        }

        if (GUILayout.Button("+ Add Folder"))
        {
            folders.Add("NewFolder",true);
        }

        GUILayout.Space(5);

        if (GUILayout.Button("Generate Folders"))
        {
            GenerateFolders();
        }
    }

    /// <summary>
    /// Generates folders in the Assets directory for all enabled entries.
    /// Skips folders that are unchecked or have empty names.
    /// </summary>
    private void GenerateFolders()
    {
        foreach (KeyValuePair<string, bool> folder in folders)
        {
            if (string.IsNullOrWhiteSpace(folder.Key)|| !folder.Value) continue;

            string path = "Assets/" + folder.Key.Trim();

            if (!AssetDatabase.IsValidFolder(path))
            {
                AssetDatabase.CreateFolder("Assets", folder.Key.Trim());
                Debug.Log("Created: " + path);
            }
            else
            {
                Debug.Log("Already exists, skipped: " + path);
            }
        }

        AssetDatabase.Refresh();
        Debug.Log("Folder setup complete!");
    }
}