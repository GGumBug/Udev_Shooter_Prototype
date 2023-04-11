using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Common")]
    [SerializeField]
    private float       _speed = 10.0f;
    [SerializeField]
    private float       _shotDelay = 0.1f;
    [SerializeField]
    private Transform   _shotPos;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject  _shotPrefab;

    private bool        _isShot;

    private Vector3     _min, _max;
    private Vector2     _colSize;
    private Vector2     _chrSize;

    private void Start()
    {
        _min        = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        _max        = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        _colSize    = GetComponent<BoxCollider2D>().size;
        _chrSize    = new Vector2(_colSize.x /2 , _colSize.y / 2);
    }

    void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.Space) && !_isShot)
            Shot();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dir         = new Vector3(x, y, 0).normalized;
        transform.position  += dir * _speed * Time.deltaTime;

        float newX  = transform.position.x;
        float newY  = transform.position.y;
        newX        = Mathf.Clamp(newX, _min.x + _chrSize.x, _max.x - _chrSize.x);
        newY        = Mathf.Clamp(newY, _min.y + _chrSize.y, _max.y - _chrSize.y);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            GemController gem = collision.GetComponent<GemController>();
            GameManager.GetInstance().gold += gem.coinValue;
            Debug.Log(GameManager.GetInstance().gold);
            Destroy(collision.gameObject);
        }
    }

    // Mathf.Clamp를 사용하면 코드를 줄일 수 있다.
    /*private void CheckEdge()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (newX < _min.x + _chrSize.x)
            newX = _min.x + _chrSize.x;
        if (newX > _max.x - _chrSize.x)
            newX = _max.x - _chrSize.x;
        if (newY < _min.y + _chrSize.y)
            newY = _min.y + _chrSize.y;
        if (newY > _max.y - _chrSize.y)
            newY = _max.y - _chrSize.y;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }*/

    private void Shot()
    {
        _isShot = true;

        StopCoroutine("IEShot");
        StartCoroutine("IEShot");
    }

    private IEnumerator IEShot()
    {
        Instantiate(_shotPrefab, _shotPos.position, Quaternion.identity);
        yield return new WaitForSeconds(_shotDelay);

        _isShot = false;
    }
}
