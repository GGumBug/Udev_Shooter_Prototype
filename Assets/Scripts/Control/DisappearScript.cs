using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    private float time = 1.0f;
    private void Start()
    {
        Destroy(gameObject, time);
    }
}
