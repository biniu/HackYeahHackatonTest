using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Transform groundCheckTransform = null ;
    private bool _jumpKeyWasPressed;
    
    private int _superJumpsRemaining = 0;
    private float _horizontalInput;

    private Rigidbody _rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpKeyWasPressed = true;
        }

        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }
       
        if (_jumpKeyWasPressed)
        {
            uint jumpPower = 7;
            if (_superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                _superJumpsRemaining--;
            }
            _rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            _jumpKeyWasPressed = false;
        }
        
        _rigidbodyComponent.velocity = new Vector3(_horizontalInput, _rigidbodyComponent.velocity.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            _superJumpsRemaining++;
        }
    }
}