using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    GameManager gameManager;
    public float _velocity = 1.0f;
    public Rigidbody2D _rigidbody;
    public bool isDeath;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = Vector2.up * _velocity;
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "ScoreArea")
        {
            gameManager.IncreaseScore();
        }    
    }
}
