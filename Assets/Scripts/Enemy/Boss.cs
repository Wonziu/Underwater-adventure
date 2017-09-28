using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Character
{
    [HideInInspector]
    public int MaxHealthPoints;

    public int HealthPoints;
   
    private void Start()
    {
        MaxHealthPoints = HealthPoints;
    }

    public override void KillCharacter()
    {
        HealthPoints--;      
        if (HealthPoints <= 0)
            gameObject.SetActive(false);
    }
}
