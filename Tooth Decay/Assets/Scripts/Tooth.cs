using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour
{

    private GameObject damageSpawnerReference;
    private int holesLeftToPath;
    private int holesPathed;

    // Use this for initialization
    private void Start()
    {
        // Spawn the holes
        GameObject.Find("DamageSpawner").GetComponent<DamageSpawner>().spawnDamage();
    }

    // Update is called once per frame
    private void Update()
    {

    }

}
