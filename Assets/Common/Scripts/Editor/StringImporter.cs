using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Text.RegularExpressions;
 
[CreateAssetMenu(fileName = "New String Importer", menuName = "Localization/String Importer")]
public class StringImporter : ScriptableObject
{
    [Header("Data Source Files (Comma Delimited)")]
    public TextAsset CommaSeparatedFile;
    
    public void Import()
    {
        
        if (CommaSeparatedFile == null)
        {
            Debug.LogError("A comma delimited file reference is required.");
            return;
        }
        Dictionary<string, int> langNames = new Dictionary<string, int>();
        
        if (langNames.Count == 0)
        {
            Debug.LogError("At least one language needs to be configured in LocalizationSettings.");
            return;
        }
        Dictionary<string, int> fieldNames = new Dictionary<string, int>();
 
        string pattern = "\n(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
 
        var lines = Regex.Split(CommaSeparatedFile.text, pattern);
 
 
       
        var isFieldNameRow = true;
        // We need at minimum the Field Names Row and a Data Row
        if (lines.Length < 2)
        {
            Debug.LogError("The tab delimited file needs to contain at minimum a field name row and a data row.");
            return;
        }
        
       
        for (uint i = 0; i < lines.Length; i++)
        {
            var line = Regex.Split(lines[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
           
           
            if (isFieldNameRow)
            {
                for (int j = 0; j < line.Length; j++)
                {
                    Debug.Log(line[j] + "," + j);
         
                    fieldNames.Add(line[j], j);
                }
                isFieldNameRow = false;
            }
            
        }
        Debug.Log("Finished importing text");
    }
}
 
[CustomEditor(typeof(StringImporter))]
public class TestScriptableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (StringImporter)target;
 
        if (GUILayout.Button("Import Language Strings", GUILayout.Height(40)))
        {
            script.Import();
        }
    }
}
 