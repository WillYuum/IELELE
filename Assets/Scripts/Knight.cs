using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{


    [SerializeField] private float _moveSpeed = 4;
    [SerializeField] private float _minDistToHit = 1;

    private Transform _mainCharacter;
    private bool isStunned = false;

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

        if (isStunned) return;

        float dist = Vector3.Distance(transform.position, _mainCharacter.position);
        transform.LookAt(_mainCharacter.transform);

        if (dist < _minDistToHit)
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

    public void GetStunned()
    {
        isStunned = true;
    }

    public void RemoveStun()
    {
        isStunned = false;
    }
}
