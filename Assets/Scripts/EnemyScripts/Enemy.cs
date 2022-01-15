using UnityEngine;
using System.Collections;
using Classes;

public class Enemy : MonoBehaviour
{
    protected GameManager _gameManager;


    public Enemy()
    {
        /// Initialisierung des GameManagers
        _gameManager = GameManager.GetInstance();
    }

    /// <summary>
    /// Variable <c>speed </c> enthaelt die Geschwindigkeit des Vogels
    /// </summary>
    public float speed;

    /// <summary>
    /// Variable <c>_speed </c> enthaelt die Anfangsgeschwindigkeit des Vogels
    /// </summary>
    public float startSpeed = 2f;

    /// <summary>
    /// Variable <c> dist </c> enthaelt zurueckgelegte Strecke des Vogels
    /// </summary>
    private float _dist = 0;
   
    public float Dist {
        get => _dist;
    }

    /// <summary>
    /// Variable <c> _oldPos </c> enthaelt die alte Position des Vogels
    /// </summary>
    private Vector3 _oldPos;

    /// <summary>
    /// Variable <c> health </c> enthaelt Leben des Vogels
    /// </summary>
    protected float _health;
    public float Health {
        get => _health;
    }

    /// <summary>
    /// Variable <c> worth </c> enthaelt Wert des Vogels
    /// </summary>
    protected int _worth;


    /// <summary>
    /// Variable <c> worth </c> enthaelt Wert des Vogels
    /// </summary>
    protected int _birdDamage;


    /// <summary>
    /// Variable <c>_onFire </c> prueft ob ein Vogel bereits brennt
    /// </summary>
    private bool _onFire;

    public bool OnFire {
        get => _onFire;
    }

    void Start()
    {
        startSpeed = speed;
    }

    void Update()
    {
        /// Erhoeht die zurueckgelegte Strecke 
        Vector3 _distanceVector = transform.position - _oldPos;
        float _distanceThisFrame = _distanceVector.magnitude;
        _dist += _distanceThisFrame;
        _oldPos = transform.position;
    }

    /// <summary>
    /// Reduziert das Leben um den mitgegebenen Wert
    /// </summary>
    /// <param name ="_dmg"> zugefuegter Schaden </param>
    public void TakeDamage (float _dmg)
    {
        _health -= _dmg;

        if (_health <= 0)
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

        speed = speed * (1f - _pct);

        if (speed <= startSpeed/2)
        {
            speed = startSpeed / 2;
        }
       /// Debug.Log("Geschwindigkeit : " + speed + "StartSpeed :" + startSpeed);

    }

    /// <summary>
    /// prueft ob eingehender Stachel vom Feuerturm kommt und ob der Vogel bereits brennt
    /// </summary>
    /// <param name ="other"> ankommender Stachel </param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("EISSTACHEL TRIFFT");

        if (collision.gameObject.tag == "Fire" && !_onFire)
        {
            StartCoroutine(TakeFire(2, 3, 5));
        }
    }

    /// <summary>
    /// Reduziert das Leben um den mitgegebenen Wert, ueber mehrere Ticks
    /// </summary>
    /// <param name ="amount"> zugefuegter Schaden </param>
    /// <param name ="count"> Anzahl der Ticks </param>
    /// <param name ="duration"> Zeit zwischen den Ticks </param>
    public IEnumerator TakeFire(float amount, float count, float duration)
    {
    
         int currentCount = 0;

        if (!_gameManager.Paused)
        {
            while (currentCount < count)
            {
                TakeDamage(amount);
                yield return new WaitForSeconds(duration);
                currentCount++;
            }
        }
    }
    /// <summary>
    /// Toetet den Vogel und fuegt Coins beim Spieler hinzu
    /// </summary>
    void Kill()
    {
        Destroy(gameObject);


        _gameManager.AddCoins(_worth);
    }

    /// <summary>
    /// Zerstoert Vogel am Ende des Weges und zieht dem Spieler Leben ab
    /// </summary>
    public void Die()
    {
        _gameManager.ReduceLives(_birdDamage);

        Destroy(gameObject);

        Debug.Log(_gameManager.Lives);
    }
}
