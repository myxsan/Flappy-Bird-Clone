using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float _velocity = 1.0f;
    public Rigidbody2D _rigidbody;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = Vector2.up * _velocity;
        }   
    }
}
