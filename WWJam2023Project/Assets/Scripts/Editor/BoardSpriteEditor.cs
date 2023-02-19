using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoardSprite), editorForChildClasses: true)]
public class BoardSpriteEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BoardSprite bs = target as BoardSprite;
        if (GUILayout.Button("Switch To Pure"))
            bs.SwitchToPure();
        if (GUILayout.Button("Switch To Corrupt"))
            bs.SwitchToCorrupt();
    }
}
