using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private float _startingHealth = 100;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            GameManager.instance.LoseGame();
        }
    }
}
