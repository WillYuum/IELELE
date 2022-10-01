using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private float _durationToFillOneBar = 1.0f;
    private int _currentResouceCount = 0;
    private int _maxResourceCount = 5;


    private float _timePassed = 0;
    private float _currentResourceValue = 0.0f;

    [SerializeField] private Slider[] _sliders;

    private void Awake()
    {
        foreach (var slider in _sliders)
        {
            slider.value = 0.0f;
        }
        _currentResouceCount = 0;
    }


    void Update()
    {
        IncreaseResourceCount();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RemoveResourceCount(1);
        }
    }

    private void IncreaseResourceCount()
    {
        if (_currentResouceCount >= _maxResourceCount) return;

        _currentResourceValue += Time.deltaTime;

        _currentResourceValue = Mathf.Clamp(_currentResourceValue, 0.0f, 1.0f);

        _sliders[_currentResouceCount].value = _currentResourceValue;

        if (_currentResourceValue >= 1)
        {
            _currentResouceCount += 1;
            _currentResourceValue = 0.0f;
        }


    }

    public void RemoveResourceCount(int amount)
    {
        float amountToRemove = Mathf.Clamp(amount, 0.0f, 1.0f);

        _timePassed -= amountToRemove;
        if (_timePassed <= 0) _timePassed = 0;

        Slider[] slidersToEmpty = new Slider[amount];

        for (int i = 0; i < amount; i++)
        {
            _currentResouceCount = Mathf.Clamp(_currentResouceCount, 0, _maxResourceCount - 1);
            slidersToEmpty[i] = _sliders[_currentResouceCount];
            _currentResouceCount--;
            _currentResouceCount = Mathf.Clamp(_currentResouceCount, 0, _maxResourceCount - 1);
        }

        // for (int i = amount - 1; i >= 0; i--)
        // {
        // }


        float totalAmountRemoved = amount;
        foreach (var item in slidersToEmpty)
        {
            item.value -= totalAmountRemoved;
            totalAmountRemoved -= amountToRemove;
        }
    }
}
