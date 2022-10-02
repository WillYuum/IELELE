using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnActive : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
