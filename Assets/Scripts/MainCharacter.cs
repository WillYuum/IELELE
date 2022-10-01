using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    private float _startingHealth = 100;
    private float _currentHealth;


    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _currentHealth = _startingHealth;
        _slider.value = 1;

    }

    private void Update()
    {
        _slider.transform.LookAt(Camera.main.transform);
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        _slider.value = _currentHealth / _startingHealth;

        if (_currentHealth <= 0)
        {
            GameManager.instance.LoseGame();
        }
    }
}
