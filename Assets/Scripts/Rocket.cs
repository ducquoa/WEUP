using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 7f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.up * (-1) * speed * Time.deltaTime); 
    }
}
