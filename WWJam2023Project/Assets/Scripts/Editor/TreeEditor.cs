using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tree), editorForChildClasses: true)]
public class TreeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Tree t = target as Tree;
        if (GUILayout.Button("TakeDamage"))
            t.TakeDamage();
    }
}