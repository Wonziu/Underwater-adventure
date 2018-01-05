using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpriteRenderer))]
public class TileEditor : Editor
{
    public void OnSceneGUI()
    {
        Event e = Event.current;

        SpriteRenderer mySpriteRenderer = (SpriteRenderer)target;

        Transform parent = mySpriteRenderer.gameObject.transform.parent;
        if (parent == null) return;

        TilesController myTilesController = parent.GetComponent<TilesController>();
        if (myTilesController == null) return;

        if (e.type == EventType.KeyDown)
        {
            if (e.keyCode == KeyCode.Keypad1)
                myTilesController.ChangeSprite(-1, mySpriteRenderer);
            else if (e.keyCode == KeyCode.Keypad2)
                myTilesController.RotateTile(mySpriteRenderer.transform);
            else if (e.keyCode == KeyCode.Keypad3)
                myTilesController.ChangeSprite(1, mySpriteRenderer);        
        }
    }
}