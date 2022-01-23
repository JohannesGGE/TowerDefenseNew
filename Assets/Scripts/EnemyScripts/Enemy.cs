using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Classes;


public class Enemy : MonoBehaviour
{
    protected GameManager _gameManager;


    public Enemy()
    {
        /// Initialisierung des GameManagers
        _gameManager = GameManager.GetInstance();
    }
    
    private string enemyTag = "Bird";

    /// <summary>
    /// Variable <c>speed </c> enthaelt die Geschwindigkeit des Vogels
    /// </summary>
    [HideInInspector]
    public float speed;

    /// <summary>
    /// Variable <c>_speed </c> enthaelt die Anfangsgeschwindigkeit des Vogels
    /// </summary>
    [HideInInspector]
    public float startSpeed = GameValues.EnemyInitialSpeed;

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

    /// <summary>
    /// Variable <c>_activeSlowHits </c> enthält wie viele active Slow Hits existieren
    /// </summary>
    private int _activeSlowHits = 0;

    /// <summary>
    /// Variable <c>soundManager </c> enthält soundManager
    /// </summary>
    protected SoundManager soundManager;

    /// <summary>
    /// Variable <c> sprite </c> enthält Sprite
    /// </summary>
    protected SpriteRenderer sprite;

    /// <summary>
    /// Variable <c> _currentCount </c> enthält Ticks der Feuerstachel
    /// </summary>
    protected int _currentCount;

    /// <summary>
    /// Variable <c> _fireDmg </c> enthält Damage der Feuerstachel
    /// </summary>
    protected float _fireDmg;

    protected ParticleSystem particleSystem;

    protected void Start()
    {
        speed = startSpeed;
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        sprite = GetComponent<SpriteRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
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
    public void TakeSlow (float _pct, float duration)
    {
        StartCoroutine(SlowDmg(_pct, duration));
    }

    private IEnumerator SlowDmg(float _pct, float duration) {
        _activeSlowHits++;
         
        speed = speed * (1f - _pct);
        if (speed <= startSpeed / GameValues.ReducedSpeed)
        {
            speed = startSpeed / GameValues.ReducedSpeed;
        }
        sprite.color = new Color(0,35,255,255);
        yield return new WaitForSeconds(duration);
        
        _activeSlowHits--;
        if(_activeSlowHits == 0) {
            sprite.color = new Color(255, 255, 255, 255);
            speed = startSpeed;
        }
    }

    public void TakeFire(float amount, float count, float duration)
    {
        _fireDmg = amount;

        if(_onFire)
        {
            _currentCount = 0;
        }

        else
        {
            _onFire = true;
            StartCoroutine(FireDmg(count, duration));
        }
    }
    /// <summary>
    /// Reduziert das Leben um den mitgegebenen Wert, ueber mehrere Ticks
    /// </summary>
    /// <param name ="amount"> zugefuegter Schaden </param>
    /// <param name ="count"> Anzahl der Ticks </param>
    /// <param name ="duration"> Zeit zwischen den Ticks </param>
    public IEnumerator FireDmg(float count, float duration)
    {
         _currentCount = 0;
         particleSystem.Play();

        while (_currentCount < count)
            {
                TakeDamage(_fireDmg);
                yield return new WaitForSeconds(duration);
                _currentCount++;
            }
            _onFire = false;
            particleSystem.Stop();
    }
    /// <summary>
    /// Toetet den Vogel und fuegt Coins beim Spieler hinzu
    /// </summary>
    void Kill()
    {
        _gameManager.AddCoins(_worth);
        TrySetLastEnemyKilled();
        Destroy(gameObject);
    }

    /// <summary>
    /// Zerstoert Vogel am Ende des Weges und zieht dem Spieler Leben ab
    /// </summary>
    public void Die()
    {
        _gameManager.ReduceLives(_birdDamage);
        TrySetLastEnemyKilled();
        Destroy(gameObject);
        soundManager.PlayDeath();
    }
    
    private void TrySetLastEnemyKilled() {
        /// Array mit lebenden Voegeln anlegen
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        if(_gameManager.AllEnemySpawned) {
            /// wenn letzter Gegner getoetet ist 
            if(enemies.Length == 1) {
                _gameManager.LastEnemyKilled = true;
            }
        }
    }
}
