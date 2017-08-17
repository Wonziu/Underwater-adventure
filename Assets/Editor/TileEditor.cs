using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpriteRenderer))]
public class TileEditor : Editor
{
    void OnSceneGUI()
    {
        Event e = Event.current;

        var sr = (SpriteRenderer)target;

        var parent = sr.gameObject.transform.parent;
        if (parent == null) return;

        var snapper = parent.GetComponent<EditorGame>();
        if (snapper == null) return;

        if (e.type == EventType.keyDown)
        {
            if (e.keyCode == KeyCode.O)
                snapper.ChangeSprite(-1, sr);
            if (e.keyCode == KeyCode.P)
                snapper.ChangeSprite(1, sr);
        }
    }
}