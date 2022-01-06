using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// Variable <c>_speed </c> enthaelt die Geschwindigkeit des Vogels
    /// </summary>
    public float _speed = 10f;
    private float _dist = 0;
    /// <summary>
    /// Variable <c>_dist </c> enthaelt zurueckgelegte Strecke des Vogels
    /// </summary>
    public float dist {
        get => _dist;
        set => _dist = value;
    }
    Vector3 oldPos;
    private Transform target;
    private int wavepointIndex = 0;

    /// <summary>
    /// Variable <c>_health </c> enthaelt Leben des Vogels
    /// </summary>
    private float _health = 100;
    public float health {
        get => _health;
        set => _health = value;
    }
    /// <summary>
    /// Variable <c>_onFire </c> prueft ob ein Vogel bereits brennt
    /// </summary>
    private bool _onFire;
    private float duration = 5;
    private float amount = 10;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        /// <summary>
        /// Bestimmt die Richtung und Geschwindigkeit der Voegel
        /// </summary>
       
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);
    
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        /// <summary>
        /// Erhoeht die zurueckgelegte Strecke 
        /// </summary>
        Vector3 _distanceVector = transform.position - oldPos;
        float _distanceThisFrame = _distanceVector.magnitude;
        _dist += _distanceThisFrame;
        oldPos = transform.position;
    }

    /// <summary>
    /// waehlt den naechsten Waypoint aus und zerstoert den Vogel, falls es der letzte Waypoint ist
    /// </summary>
    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Die();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    /// <summary>
    /// Reduziert das Leben um den mitgegebenen Wert
    /// </summary>
    /// <param name ="_dmg"> zugefuegter Schaden </param>
    public void TakeDamage (float _dmg)
    {
        health -= _dmg;

        if (health <= 0)
        {
            Kill();
        }
    }
    /// <summary>
    /// Reduziert die Geschwindigkeit um den mitgegebenen Wert, in Prozent
    /// </summary>
    /// <param name ="_pct"> abzuziehende Geschwindigkeit </param>
    public void TakeSlow (float _pct)
    {
        _speed = _speed * (1f - _pct);
    }
    /// <summary>
    /// prueft ob eingehender Stachel vom Feuerturm kommt und ob der Vogel bereits brennt
    /// </summary>
    /// <param name ="other"> ankommender Stachel </param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire" && !_onFire)
        {
            StartCoroutine(TakeFire(amount, 3, duration));
        }
    }

    /// <summary>
    /// Reduziert das Leben um den mitgegebenen Wert, ueber mehrere Ticks
    /// </summary>
    /// <param name ="amount"> zugefuegter Schaden </param>
    /// <param name ="count"> Anzahl der Ticks </param>
    /// <param name ="duration"> Zeit zwischen den Ticks </param>
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
    /// <summary>
    /// Toetet den Vogel und fuegt Coins beim Spieler hinzu
    /// </summary>
    void Kill()
    {
        Destroy(gameObject);

        //SpielerGeld geht hoch
    }

    /// <summary>
    /// Zerstoert Vogel am ende des Weges und zieht dem Spieler Leben ab
    /// </summary>
    void Die()
    {
        //SpielerLeben gehen runter

        Destroy(gameObject);
    }
}
