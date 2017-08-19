using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy)), CanEditMultipleObjects]
public class EnemyPathEditor : Editor
{
    public void OnSceneGUI()
    {
        Enemy enemy = (Enemy)target;

        Vector2[] path = enemy.Waypoints;

        EditorGUI.BeginChangeCheck();

        for (int i = 0; i < path.Length; i++)
        {
            path[i] = Handles.PositionHandle(path[i], Quaternion.identity);

        }
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(enemy, "Path change");
            enemy.Waypoints = path;
        }
    }
}