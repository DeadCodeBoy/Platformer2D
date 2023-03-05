using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameOver _gameOverTemplate;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3[] _positions;

    private int currentTarget;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _positions[currentTarget], _speed);
        
        if (transform.position == _positions[currentTarget])
        {
            if(currentTarget<_positions.Length-1)
            {
                currentTarget++;
                _sprite.flipX = false;
            }
            else
            {
                currentTarget = 0;
                _sprite.flipX = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out PlayerMovement player))
        {
            Destroy(collision.gameObject);
            Instantiate(_gameOverTemplate,transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement player))
        {
            Destroy(gameObject);
        }
    }
}
