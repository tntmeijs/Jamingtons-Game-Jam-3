using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpawner : MonoBehaviour
{

    public Texture2D spriteSheet;

    private Sprite[] sprites;

    // Use this for initialization
    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>(spriteSheet.name);
        Debug.Log(sprites.Length);
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
