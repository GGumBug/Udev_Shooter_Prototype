using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.5f;
    [SerializeField]
    private int _moveCount;

    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ResetBackground();
    }

    private void ResetBackground()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
        Vector3 pos = transform.position;
        if (pos.x + _sprite.bounds.size.x / 2 < -8)
        {
            float size = _sprite.bounds.size.x * _moveCount;
            pos.x += size;
            transform.position = pos;
        }
    }


}
