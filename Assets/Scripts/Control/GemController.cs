using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.5f;
    public int coinValue;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
