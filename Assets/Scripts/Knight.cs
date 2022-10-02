using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{


    [SerializeField] private float _moveSpeed = 4;
    [SerializeField] private float _minDistToHit = 1;

    private Transform _mainCharacter;
    private bool isStunned = false;

    [SerializeField] private float _startingHealth = 200;
    private float _currentHealth;

    [SerializeField] private float _attackCooldownPerSec = 2;
    private float _attackCooldownTimer = 0;

    [SerializeField] private Slider _healthSlider;


    [SerializeField] private float _damageToInflict = 20;

    void Awake()
    {
        _currentHealth = _startingHealth;

        _mainCharacter = GameObject.FindGameObjectWithTag("Animal").transform;
        if (_mainCharacter == null)
        {
            Debug.LogError("No main character found");
        }

        _attackCooldownTimer = 0;
        _healthSlider.value = _currentHealth / _startingHealth;
    }

    private void Update()
    {
        AttackPlayer();
        _healthSlider.transform.LookAt(Camera.main.transform);
    }


    public void AttackPlayer()
    {

        if (_mainCharacter == null)
        {
            return;
        }

        if (isStunned) return;


        float dist = Vector3.Distance(transform.position, _mainCharacter.position);
        Vector3 PlayerPos = _mainCharacter.transform.position;


        transform.LookAt(PlayerPos);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        // transform.rotation = Quaternion.LookRotation(flatPlayerPos);
        // transform.rotation

        // transform.LookAt(flatPlayerPos);

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
            _attackCooldownTimer = 0;
        }
    }


    private void HitPlayer()
    {
        // _mainCharacter = GameObject.FindGameObjectWithTag("Animal").transform;
        _mainCharacter.GetComponent<MainCharacter>().TakeDamage(_damageToInflict);
    }

    public void GetAngry()
    {

    }

    public void GetStunned()
    {
        isStunned = true;
    }

    private void RemoveStun()
    {
        isStunned = false;
    }

    public void TakeDamage(int amount)
    {
        print("Knight take damage");

        _currentHealth -= amount;

        _healthSlider.value = _currentHealth / _startingHealth;

        if (_currentHealth <= 0)
        {
            KnightScene.instance.OnKillKnight();
            Destroy(gameObject);
        }
    }
}
