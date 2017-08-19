using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TilesController))]
public class PrefabPlacerEditor : Editor
{
    public void OnSceneGUI()
    {
        Event e = Event.current;

        Vector3 mousePosition = Event.current.mousePosition;
        mousePosition.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePosition.y;
        mousePosition = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;


        TilesController myTilesController = (TilesController) target;


        if (e.type == EventType.keyDown)
        {
            if (e.keyCode == KeyCode.S)
                myTilesController.PlacePrefab(mousePosition, 0);      
        }
    }
}
