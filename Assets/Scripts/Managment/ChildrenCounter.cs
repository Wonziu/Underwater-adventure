using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ChildrenCounter : MonoBehaviour
{
	void Start ()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).name = i.ToString();
        }
        DestroyImmediate(this);
	}
}