
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform _mainCharacter;
    [SerializeField] private float _hieght = 10f;
    [SerializeField] private float _distance = 10f;
    [SerializeField] private float _angle = 0.125f;


    private Vector3 refVelocity;


    private void Awake()
    {
        _mainCharacter = GameObject.FindGameObjectWithTag("Animal").transform;
        if (_mainCharacter == null)
        {
            Debug.LogError("No main character found");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HandleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
    }


    private void HandleCamera()
    {
        if (_mainCharacter == null)
        {
            return;
        }

        Vector3 worldPosition = (Vector3.forward * -_distance) + (Vector3.up * _hieght);

        Vector3 rotatedVector = Quaternion.AngleAxis(_angle, Vector3.up) * worldPosition;

        Vector3 newTargetPosition = _mainCharacter.position;
        newTargetPosition.y = 0f;
        Vector3 finalPosition = newTargetPosition + rotatedVector;

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, 0.5f);
        transform.LookAt(newTargetPosition);
    }
}
