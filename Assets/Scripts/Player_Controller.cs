using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Game_Manager gm;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float[] _posX;
    [SerializeField] private bool _isHit;
    [SerializeField] private bool _isRight;

    void Start()
    {

    }


    void Update()
    {
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            transform.position.y,
            transform.position.z
        ));

        if (Input.GetMouseButtonDown(0) && _isHit == true && _mousePos.x >= _posX[0] && _mousePos.x <= _posX[1])
        {
            rb.velocity = new Vector2(
                _moveSpeed,
                rb.velocity.y
            );
            
            Flip();
            
            _isHit = false;
            if (!_isHit) _moveSpeed *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            _isHit = true;
        }
    }

    private void Flip()
    {
        _isRight = !_isRight;
        transform.Rotate(0f,180f,0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            gm._score++;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            gm.GameOver();
        }
    }
}    