using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    static public float interpolateAnticipate(float fractionNormalized)
    {
        float tension = 4.0f;
        return fractionNormalized * fractionNormalized * ((tension + 2.0f) * fractionNormalized - tension);
    }

}
