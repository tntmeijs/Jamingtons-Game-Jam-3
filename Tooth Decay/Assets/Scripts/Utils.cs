using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    static public float interpolateAnticipate(float fractionNormalized, float tension = 0.4f)
    {
        return fractionNormalized * fractionNormalized * ((tension + 2.0f) * fractionNormalized - tension);
    }

    static public float interpolateSpring(float fractionNormalized, float factor = 0.6f)
    {
        return Mathf.Pow(2.0f, -10.0f * fractionNormalized) * Mathf.Sin((fractionNormalized - factor / 4.0f) * (2.0f * Mathf.PI) / factor) + 1.0f;
    }

}
