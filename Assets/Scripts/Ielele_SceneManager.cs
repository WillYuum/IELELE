using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ielele_SceneManager : MonoBehaviour
{
    [SerializeField] GameObject hora;
    [SerializeField] Ielele_Trigger IT;

    AudioSource ieleleSong;

    private Vector3 horaPosition;

    private bool horaStart;

    // Start is called before the first frame update
    void Start()
    {
        horaPosition = new Vector3(34.75f, -1.0f, 39.98f);
        horaStart = false;

    }

    private GameObject enemyLeft;

    // Update is called once per frame
    void Update()
    {
        if (horaStart == false && IT.triggerHora == true)
        {
            enemyLeft = Instantiate(
           hora,
           horaPosition,
           Quaternion.Euler(0f, 0f, 0f),
           transform);

            ieleleSong = GetComponent<AudioSource>();
            ieleleSong.Play(0);


            horaStart = true;
        }

        Debug.Log("Hora start is " + horaStart + "; triggerHora is" + IT.triggerHora);

    }



    [SerializeField] private ParticleSystem endPoint;
    [SerializeField] private EventCollider endPointCollider;


    public void onFinishIelele()
    {
        Destroy(enemyLeft);
        endPointCollider.action += LeaveMap;
    }


    private void LeaveMap(Collider other)
    {
        if (other.tag == "Animal")
        {
            GameManager.instance.GoToScene(GameScenes.Map);
        }
    }




}
