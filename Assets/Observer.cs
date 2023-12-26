using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer
{
    public static Observer Instance => _instance ??= new Observer();
    public Queue<Record> Recorder => _recorder;

    private static Observer _instance = null;
    private Queue<Record> _recorder = new Queue<Record>();
}
