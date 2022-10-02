using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour
{
    private Transform _mainCharacter;
    [SerializeField] private Transform _minPos;
    [SerializeField] private Transform _maxPos;
    private void Awake()
    {
        // transform.position = Vector3.zero;
        _mainCharacter = GameObject.FindGameObjectWithTag("Animal").transform;
    }

    private void LateUpdate()
    {
        KeepPlayerInBounds();
    }

    public void KeepPlayerInBounds()
    {
        Vector3 pos = _mainCharacter.position;
        pos.x = Mathf.Clamp(pos.x, _minPos.position.x, _maxPos.position.x);
        pos.z = Mathf.Clamp(pos.z, _minPos.position.z, _maxPos.position.z);
        _mainCharacter.position = pos;
    }

}
