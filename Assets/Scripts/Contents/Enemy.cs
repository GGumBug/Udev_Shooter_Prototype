using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject _coinPrefab;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _enemyShotPrefab;

    public int type;
    public int hp;
    public float speed = 3;
    public int value;
    public float time;
    public float maxShotTime = 2;
    public float shotSpeed;
    private void Start()
    {
        switch (type)
        {
            case 0:
                hp = 10; speed = 1.5f; value = 3; maxShotTime = 3; shotSpeed = 3;
                break;
            case 1:
                hp = 20; speed = 1.4f; value = 4; maxShotTime = 2; shotSpeed = 4;
                break;
            case 2:
                hp = 100; speed = 2f; value = 5; maxShotTime = 1; shotSpeed = 5;
                break;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > maxShotTime)
        {
            time = 0;
            GameObject go = Instantiate(_enemyShotPrefab, transform.position, Quaternion.identity);
            EnemyShot enemy = go.GetComponent<EnemyShot>();
            enemy._speed = shotSpeed;
        }

        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    public void MinusHP(int atk)
    {
        hp -= atk;
        if (hp <= 0)
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
        gem.coinValue = GetComponent<Enemy>().value;
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
