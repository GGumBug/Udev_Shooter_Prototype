using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float _speed = 4.0f;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
