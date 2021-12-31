using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float distance = 0;
    Vector3 oldPos;
    private Transform target;
    private int wavepointIndex = 0;
    private float health = 50;
    private bool onFire;
    private float duration = 5;
    private float amount = 10;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        // Zurückgelegten Weg berechnen
        Vector3 distanceVector = transform.position - oldPos;
        float distanceThisFrame = distanceVector.magnitude;
        distance += distanceThisFrame;
        oldPos = transform.position;
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeSlow (float amount)
    {
        speed = speed * (1f - amount);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire" && !onFire)
        {
            StartCoroutine(TakeFire(amount, 3, duration));
        }
    }

    IEnumerator TakeFire(float amount, float count, float duration)
    {
    
         int currentCount = 0;

            while (currentCount < count)
            {
                TakeDamage(amount);
                yield return new WaitForSeconds(duration);
                currentCount++;
            }
        
    }

    void Die()
    {
        Destroy(gameObject);

        //SpielerGeld geht hoch
    }
}
