using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{


    [SerializeField] private float _moveSpeed = 4;
    [SerializeField] private float _minDistToHit = 5;

    private Transform _mainCharacter;

    [SerializeField] private float _attackCooldownPerSec = 2;
    private float _attackCooldownTimer = 0;

    void Awake()
    {
        _mainCharacter = GameObject.FindGameObjectWithTag("Animal").transform;
        if (_mainCharacter == null)
        {
            Debug.LogError("No main character found");
        }

        _attackCooldownTimer = _attackCooldownPerSec;
    }

    private void Update()
    {
        AttackPlayer();
    }


    public void AttackPlayer()
    {
        if (_mainCharacter == null)
        {
            return;
        }

        float dist = Vector3.Distance(_mainCharacter.position, transform.position);
        transform.LookAt(_mainCharacter);

        if (_minDistToHit < dist)
        {
            if (_attackCooldownTimer > _attackCooldownPerSec)
            {
                _attackCooldownTimer = 0;
                //Hit main player
                HitPlayer();
            }
            else
            {
                _attackCooldownTimer += Time.deltaTime;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _mainCharacter.position, _moveSpeed * Time.deltaTime);
            _attackCooldownTimer = _attackCooldownPerSec;
        }
    }


    private void HitPlayer()
    {
        // _mainCharacter = GameObject.FindGameObjectWithTag("Animal").transform;
        _mainCharacter.GetComponent<MainCharacter>().TakeDamage(10);
    }
}
