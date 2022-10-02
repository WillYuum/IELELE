using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasNaratives : MonoBehaviour
{
    public void GotoMapScreen()
    {
        GameManager.instance.GoToScene(GameScenes.Map);
    }
}
