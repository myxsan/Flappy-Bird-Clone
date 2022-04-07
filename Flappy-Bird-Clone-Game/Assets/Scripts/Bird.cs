using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public AudioClip hitSFX, PointSFX, jumpSFX;
    public Canvas gameOverCanvas;
    public Canvas startMenuCanvas;
    GameManager gameManager;
    public float _velocity = 1.0f;
    public Rigidbody2D _rigidbody;
    public bool isPlaying;
    public bool isDeath;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start() 
    {
        startMenuCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if(!isPlaying)
            {
                startMenuCanvas.gameObject.SetActive(false);
                isPlaying = true;
                _rigidbody.gravityScale = 0.75f;
            }
            PlaySFX(jumpSFX);
            _rigidbody.velocity = Vector2.up * _velocity;
        }   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "ScoreArea")
        {
            PlaySFX(PointSFX);
            gameManager.IncreaseScore();
        }    
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "DeathArea")
        {
            PlaySFX(hitSFX);
            isDeath = true;
            Time.timeScale = 0;
            gameOverCanvas.gameObject.SetActive(true);
        }    
    }
    public void PlaySFX(AudioClip clip)
    {
        if(gameManager.isOpenSFX)
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position);
        }
    }
}
