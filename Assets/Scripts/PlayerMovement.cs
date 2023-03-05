using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed ;
    [SerializeField] private float _jumpForce;
    
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _sprite;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>(); 
    }
        
    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * _speed * Time.deltaTime; 

        if(Input.GetKeyDown(KeyCode.Space)&& Mathf.Abs(_rigidbody.velocity.y)< 0.05f)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
        
        if(movement<0 )
        {
            _sprite.flipX =  true;
            _animator.SetBool("runing", true);
        }
        else if (movement>0)
        {
            _sprite.flipX = false;
            _animator.SetBool("runing", true);
        }
        else
        {
            _animator.SetBool("runing", false);
        }
    }
}
