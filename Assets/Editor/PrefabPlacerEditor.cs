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
            if (e.keyCode == KeyCode.Keypad1)
                myTilesController.PlaceTilePrefab(mousePosition, 0);  
            else if (e.keyCode == KeyCode.Keypad2)
                myTilesController.PlaceTilePrefab(mousePosition, myTilesController.TileSprites.Count - 1);
            else if (e.keyCode == KeyCode.Keypad3)
                myTilesController.PlaceCoinPrefab(mousePosition);
            else if (e.keyCode == KeyCode.Keypad4)
                myTilesController.PlacePlantPrefab(mousePosition, 0); 
        }
    }
}