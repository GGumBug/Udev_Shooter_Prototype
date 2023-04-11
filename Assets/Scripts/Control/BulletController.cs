using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private GameObject _shotEffectPrefab;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.right * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            AsteroidController asteroid = collision.GetComponent<AsteroidController>();
            asteroid.MinusHP(3);
            Instantiate(_shotEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.MinusHP(3);
            Instantiate(_shotEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
