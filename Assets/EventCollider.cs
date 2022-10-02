using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCollider : MonoBehaviour
{
    public event Action<Collider> action;


    private void OnTriggerEnter(Collider other)
    {
        action.Invoke(other);
    }
}
