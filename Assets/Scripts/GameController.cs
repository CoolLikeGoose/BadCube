using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private bool lockFPS;

    private void Awake()
    {
        if (lockFPS) { Application.targetFrameRate = 60; }
        else { Application.targetFrameRate = -1; }
    }
}
