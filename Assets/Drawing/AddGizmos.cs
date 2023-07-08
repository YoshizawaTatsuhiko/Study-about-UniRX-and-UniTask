﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGizmos
{
    /// <summary>新しいGizmosを追加する</summary>
    public static class AddGizmos
    {
        public static void DrawWireCone(Vector3 coneTip, Vector3 direction, float height, float circleRadius, float segments = 20f)
        {
            Vector3 dest = coneTip + direction.normalized * height;
            Gizmos.DrawLine(coneTip, dest);

            //円錐の円を描き始める地点
            Vector3 from = dest;
            from.y = circleRadius;
            Gizmos.DrawLine(dest, from);

            float degree = Mathf.PI * 2 * Mathf.Rad2Deg;

            //増加量を求める
            int addition = Mathf.RoundToInt(degree / segments);
        }
    }
}
