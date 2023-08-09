using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Vector2 diff = Vector2.zero;
    float minX = 0;
    float maxX = 1080f;
    float minY = 0;
    float maxY = 1920f;

    public float disableAfterSeconds = 3f;
    private Animator animator;

   private void OnMouseDown()
    {
        diff = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
    Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

    Vector2 clampedPosition = new Vector2(
        Mathf.Clamp(mousePosition.x - diff.x, minX, maxX),
        Mathf.Clamp(mousePosition.y - diff.y, minY, maxY)
    );

    transform.position = (Vector2)clampedPosition;
    }

    void DisableAnimatorComponent()
    {
        animator.enabled = false;
    }
    private void Start()
    { 
        minX = Camera.main.ScreenToWorldPoint(Vector2.zero).x;
        maxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        minY = Camera.main.ScreenToWorldPoint(Vector2.zero).y;
        maxY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;

        animator = GetComponent<Animator>();
        Invoke("DisableAnimatorComponent", disableAfterSeconds);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "enemy" | collision.tag == "rocket")
        {
            Destroy(gameObject);
        }
    }
}
