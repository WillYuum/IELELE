using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomeFromLoseScreen : MonoBehaviour
{
    public void GoHome()
    {
        print("PEW PEW");
        GameManager.instance.RestartGame();
    }
}
