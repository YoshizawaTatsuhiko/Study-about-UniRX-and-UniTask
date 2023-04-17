using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// 日本語対応
public class MyComparer : IComparer
{
    public int Compare(object x, object y)
    {
        float a = (float)x;
        float b = (float)y;

        if (a - b > 0)
        {
            return -1;
        }
        else if (a - b < 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    int n = Random.Range(0, 1);
}
