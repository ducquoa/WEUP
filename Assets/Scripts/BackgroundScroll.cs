using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] public float scrollSpeed = 1.25f;
    
    Vector2 offset;

    void Update()
    {
        //Debug.Log("texture not animating");
        offset = new Vector2(0, Time.deltaTime * scrollSpeed);
        GetComponent<Renderer>().material.mainTextureOffset += offset;
    }
}
