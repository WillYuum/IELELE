using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calusari_Trigger : MonoBehaviour
{
    public bool triggerCalusari;

    // Start is called before the first frame update
    void Start()
    {
        triggerCalusari = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            triggerCalusari = true;
        }

    }


}
