using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public Texture2D bandAidSpriteSheet;

    private Sprite[] sprites;
    private bool hasBandaid;
    private KeyCode activeKey;

    // All keys that can be used to patch a hole
    private List<KeyCode> keyCollection = new List<KeyCode>()
    {
        KeyCode.A,
        KeyCode.B,
        KeyCode.C,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.I,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.M,
        KeyCode.N,
        KeyCode.O,
        KeyCode.P,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.S,
        KeyCode.T,
        KeyCode.U,
        KeyCode.V,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z
    };

    // Use this for initialization
    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>(bandAidSpriteSheet.name);

        hasBandaid = false;

        pickRandomKey();

        Debug.Log(activeKey);
    }

    // Update is called once per frame
    private void Update()
    {
        // Hole should be patched by holding a random key
        if (!hasBandaid)
        {
        }
        // Hole should be fixed by polishing
        else
        {
        }
    }

    private void pickRandomKey()
    {
        activeKey = keyCollection[Random.Range(0, keyCollection.Count - 1)];
    }

}
