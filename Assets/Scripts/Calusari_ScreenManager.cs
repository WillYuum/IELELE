using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calusari_ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject calusari;
    [SerializeField] Calusari_Trigger CT;

    public GameObject calusariBand;

    public AudioSource calusariSong;

    private Vector3 calusariPosition;

    private bool calusariStart;

    // Start is called before the first frame update
    void Start()
    {
        calusariPosition = new Vector3(21.89f, 0f, 26.77f);
        calusariStart = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (calusariStart == false && CT.triggerCalusari == true)
        {
            calusariBand = Instantiate(
            calusari,
            calusariPosition,
            Quaternion.Euler(0f, 0f, 0f),
            transform);

            calusariSong = GetComponent<AudioSource>();
            calusariSong.Play(0);


            calusariStart = true;
        }


    }
}
