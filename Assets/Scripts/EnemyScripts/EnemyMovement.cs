using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;


public class EnemyMovement : MonoBehaviour
{
    private Transform _target;

    private int _wavepointIndex = 0;

    private Enemy _enemy;

    private GameManager _gameManager;

    private SpriteRenderer mySpriteRenderer;

    public EnemyMovement()
    {
        /// Initialisierung des GameManagers
        _gameManager = GameManager.GetInstance();
    }
    void Start()
    {
        _enemy = GetComponent<Enemy>();

        _target = Waypoints.points[0];

        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    /// <summary>
    /// Bestimmt die Richtung und Geschwindigkeit der Voegel
    /// </summary>
    /// 
    void Update()
    {
            Vector3 dir = _target.position - transform.position;
            transform.Translate(dir.normalized * _enemy.Speed * Time.deltaTime, Space.World);

            if(_target.position.x < transform.position.x)
            {
                mySpriteRenderer.flipX = false;
            }
            if (_target.position.x > transform.position.x)
            {
                mySpriteRenderer.flipX = true;
            }

            if (Vector3.Distance(transform.position, _target.position) <= 5f)
		{
			GetNextWaypoint();
		}
	
    }


    /// <summary>
    /// waehlt den naechsten Waypoint aus und zerstoert den Vogel, falls es der letzte Waypoint ist
    /// </summary>
	void GetNextWaypoint()
	{
		if (_wavepointIndex >= Waypoints.points.Length - 1)
		{
			_enemy.Die();
			return;
		}

		_wavepointIndex++;
		_target = Waypoints.points[_wavepointIndex];
	}
    
}
