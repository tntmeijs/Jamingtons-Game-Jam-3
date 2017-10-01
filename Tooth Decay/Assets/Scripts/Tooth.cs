using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour
{

    public bool isFixed = false;

    // Use this for initialization
    private void Start()
    {
    }

    private void LateUpdate()
    {
        if (DamageSpawner.holesLeftToPolish == 0)
        {
            isFixed = true;
        }
    }

    private void Update()
    {
    }

}
