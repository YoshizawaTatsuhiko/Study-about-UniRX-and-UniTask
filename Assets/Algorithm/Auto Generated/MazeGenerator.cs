using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private int _width = 5;
    [SerializeField] private int _height = 5;
    MazeStrategist _autoAlgorithm = new MazeStrategist(new WallExtendAlgorithm());

    private void Start()
    {
        _autoAlgorithm.AssembleFromBlueprint(_width, _height);
    }
}
