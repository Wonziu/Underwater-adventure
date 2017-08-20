using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovingEnemy)), CanEditMultipleObjects]
public class EnemyPathEditor : Editor
{
    public void OnSceneGUI()
    {
        MovingEnemy movingEnemy = (MovingEnemy)target;

        Vector2[] path = movingEnemy.Waypoints;

        EditorGUI.BeginChangeCheck();

        for (int i = 0; i < path.Length; i++)
        {
            path[i] = Handles.PositionHandle(path[i], Quaternion.identity);

        }
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(movingEnemy, "Path change");
            movingEnemy.Waypoints = path;
        }
    }
}