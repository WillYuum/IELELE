using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoraBehavior : MonoBehaviour
{
    private Transform _mainCharacter;

    private bool isStunned = false;

    private float _durationToVortexPull = 1.0f;
    private float _durationTillVortexPull = 0.0f;

    private void Awake()
    {
        _mainCharacter = GameObject.FindGameObjectWithTag("Animal").transform;
    }


    void Update()
    {
        if (isStunned == false)
        {
            return;
        }

        _durationTillVortexPull += Time.deltaTime;

        if (_durationTillVortexPull >= _durationToVortexPull)
        {
            PullMainCharacterByVortex();
        }
    }

    private void PullMainCharacterByVortex()
    {
        _mainCharacter.position = Vector3.Lerp(_mainCharacter.position, transform.position, 0.06f);
    }


    public void GetStunned()
    {
        if (isStunned) return;
        isStunned = true;

        Invoke(nameof(RemoveStun), 1.75f);
    }

    private void RemoveStun()
    {

    }
}
