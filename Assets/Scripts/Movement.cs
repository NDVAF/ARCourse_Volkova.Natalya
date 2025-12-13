using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   

    [SerializeField] private Camera _camera;
    [SerializeField] private  float _rayLength = 100.0f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _distanceToStop = 1.0f;
    [SerializeField] private float _rotationSpeed = 90f;
    private void Start()
    {

    }

    void Update()
    {

        HandleRotation();
        HandleMovement();
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, _rayLength,_layerMask))
        {
            if(Vector3.Distance(transform.position, hit.point) <= _distanceToStop)
            {
                return;
            }
            var direction = (hit.point - transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }
    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.A)) transform.Rotate(0, -_rotationSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.D)) transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S)) transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }
}
