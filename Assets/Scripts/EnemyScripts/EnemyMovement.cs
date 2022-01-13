using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0];

    }

    /// <summary>
    /// Bestimmt die Richtung und Geschwindigkeit der Voegel
    /// </summary>
    /// 
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy._startspeed;
	}

    /// <summary>
    /// waehlt den naechsten Waypoint aus und zerstoert den Vogel, falls es der letzte Waypoint ist
    /// </summary>
	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			enemy.Die();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}
    
}
