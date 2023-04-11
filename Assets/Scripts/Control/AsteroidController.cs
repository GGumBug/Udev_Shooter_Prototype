using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [Header ("Common")]
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _rotSpeed = 30.0f;

    [Header ("Prefabs")]
    [SerializeField]
    private GameObject _coinPrefab;
    [SerializeField]
    private GameObject _explosionPrefab;

    public int HP { get; private set; } = 10;
    public int value = 2;

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * _speed;
        transform.eulerAngles += Vector3.forward * Time.deltaTime * _rotSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void MinusHP(int atk)
    {
        HP -= atk;
        if (HP <= 0)
            Death();
    }

    private void Death()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Vector3 randPos = transform.position;
        randPos.x = Random.Range(-0.1f, 0.1f);
        randPos.y = Random.Range(-0.1f, 0.1f);
        GameObject coin = Instantiate(_coinPrefab, transform.position + randPos, Quaternion.identity);
        GemController gem = coin.GetComponent<GemController>();
        gem.coinValue = GetComponent<AsteroidController>().value;
        Destroy(gameObject);
    }
}
