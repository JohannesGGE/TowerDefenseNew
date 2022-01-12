using UnityEngine;
using System.Collections;
using Classes;

public class Enemy : MonoBehaviour
{
    private GameManager _gameManager;

    public Enemy()
    {
        _gameManager = GameManager.GetInstance();
    }

    /// <summary>
    /// Variable <c>speed </c> enthaelt die Geschwindigkeit des Vogels
    /// </summary>
    public float speed;

    /// <summary>
    /// Variable <c>_speed </c> enthaelt die Anfangsgeschwindigkeit des Vogels
    /// </summary>
    public float _startspeed = 10f;

    /// <summary>
    /// Variable <c> dist </c> enthaelt zurueckgelegte Strecke des Vogels
    /// </summary>
    private float _dist = 0;
   
    public float dist {
        get => _dist;
        set => _dist = value;
    }
    Vector3 oldPos;
    private Transform target;
    private int wavepointIndex = 0;

    /// <summary>
    /// Variable <c> health </c> enthaelt Leben des Vogels
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
        speed = _startspeed;
    }

    /// <summary>
    /// Bestimmt die Richtung und Geschwindigkeit der Voegel
    /// </summary>
    /// 
    void Update()
    {
       
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        speed = _startspeed;


        /// Erhoeht die zurueckgelegte Strecke 
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
        speed = _startspeed * (1f - _pct);
    }

    public void TakeFire (float amount, float count)
    {

    }

    /// <summary>
    /// prueft ob eingehender Stachel vom Feuerturm kommt und ob der Vogel bereits brennt
    /// </summary>
    /// <param name ="other"> ankommender Stachel </param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire" && !_onFire)
        {
            StartCoroutine(Fire(amount, 3, duration));
        }
    }

    /// <summary>
    /// Reduziert das Leben um den mitgegebenen Wert, ueber mehrere Ticks
    /// </summary>
    /// <param name ="amount"> zugefuegter Schaden </param>
    /// <param name ="count"> Anzahl der Ticks </param>
    /// <param name ="duration"> Zeit zwischen den Ticks </param>
    IEnumerator Fire(float amount, float count, float duration)
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

        _gameManager.AddCoins(10);
    }

    /// <summary>
    /// Zerstoert Vogel am Ende des Weges und zieht dem Spieler Leben ab
    /// </summary>
    void Die()
    {
        _gameManager.ReduceLives(5);

        Destroy(gameObject);
    }
}
