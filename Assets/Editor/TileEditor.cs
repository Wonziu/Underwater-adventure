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

        if (e.type == EventType.keyDown)
        {
            if (e.keyCode == KeyCode.Q)
                myTilesController.ChangeSprite(-1, mySpriteRenderer);
            else if (e.keyCode == KeyCode.E)
                myTilesController.ChangeSprite(1, mySpriteRenderer);
            else if (e.keyCode == KeyCode.W)
                myTilesController.RotateTile(mySpriteRenderer.transform);
        }
    }
}