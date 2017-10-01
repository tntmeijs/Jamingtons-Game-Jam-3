using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour
{
    
    public DamageSpawner damageSpawner;

    private int holesLeftToPath;
    private int holesPathed;

    // Use this for initialization
    private void Start()
    {
        damageSpawner.spawnDamage();
    }

}
