using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemyHealth = 5;
    [SerializeField] bool isInvincible = false;

    public GameObject rocket;
    public Transform rocketSpawner;
    private float fireRate;
    private float lastFireTime;
    private float randomizer;
    private int pointsForDestroy = 1;
    private Score scoreScript;
    void Start()
    {
        isInvincible = true;
        randomizer = Random.Range(4f,10f);
        fireRate = Random.Range(4f,8f);
        scoreScript = GameObject.FindObjectOfType<Score>();
    }

    void Update()
    {
        if (Time.time > lastFireTime + fireRate)
        {
            StartCoroutine(EnemyShooting());
            lastFireTime = Time.time;
            StartCoroutine(IsInvincible());
        }
    }   

    IEnumerator EnemyShooting()
    {
        yield return new WaitForSeconds(randomizer);
        InstantiateRocket();
    }

    private void InstantiateRocket()
    {
        GameObject newRocket = Instantiate(rocket, transform.position, Quaternion.identity);
        newRocket.transform.SetParent(rocketSpawner);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isInvincible==false)
        {
            if (enemyHealth >= 1) 
            {
                enemyHealth--;
                if (enemyHealth == 0)
                {
                Destroy(gameObject);
                }
            }
        
        }   
        if (isInvincible==true) { return; }
    }

    IEnumerator IsInvincible()
    {
        yield return new WaitForSeconds(20f);
        isInvincible = false;

    }
    void OnDestroy()
        {
            if (scoreScript != null)
            {
                scoreScript.AddScore(pointsForDestroy);
            }
        }
}
