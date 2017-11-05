using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MovingEnemyStats : ScriptableObject 
{
	public float MovementSpeed;
	[Range(0, 3)]
	public float Ease;
	public float WaitTime;
}
