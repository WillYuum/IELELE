using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGameObject : MonoBehaviour
{
    private Action _actionToRun;
    public void Init(Action action)
    {
        _actionToRun = action;
    }

    private void OnMouseDown()
    {
        print("CLicked");
        _actionToRun.Invoke();
    }
}
