using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonTools : MonoBehaviour
{
    public static int RandomIndex(int[] weights, int weightsSum)
    {
        int val = Random.Range(0, weightsSum);
        int j = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            j += weights[i];
            if (val < j)
                return i;
        }
        throw new System.Exception("WeightsSum does not exquals sum of weights");
    }
}
