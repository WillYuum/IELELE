using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IELELE : MonoBehaviour
{

    private bool isStunned = false;

    public void GetStunned()
    {
        isStunned = true;
    }

    private void GetUnstunned()
    {
        isStunned = false;
    }

    public void GetAngry()
    {

    }
}
