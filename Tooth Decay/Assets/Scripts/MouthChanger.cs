using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthChanger : MonoBehaviour
{

    public Texture2D mouthSpriteSheet;

    // The order in which the types are sorted must match that of the sprite sheet!
    public enum MouthTypes
    {
        SAD = 0,
        AMAZED,
        NO_EMOTION,
        HAPPY
    };

    private Sprite[] sprites;

    // Use this for initialization
    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>(mouthSpriteSheet.name);

        // Set the default mouth
        UpdateMouthSprite(MouthTypes.SAD);
    }

    public void UpdateMouthSprite(MouthTypes newType)
    {
        GetComponent<SpriteRenderer>().sprite = sprites[(int)newType];
    }

}
