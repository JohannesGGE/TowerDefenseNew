using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class TowerUpgraded : MonoBehaviour
    {
        private GameManager _gameManager;

        public TowerUpgraded()
        {
            _gameManager = GameManager.GetInstance();
        }

        private Transform target;

        [Header("Hit Effects")]
        public int towerDamage = 50;
        public string towerEffect = "ice";

        [Header("Attributes")]
        public float range = 5f;
        public float fireRate = 1f;
        private float fireCountdown = 0f;

        [Header("Unity Setup - Do not change!")]
        public string enemyTag = "Bird";
        public Transform partToRotate;
        public float turnSpeed = 10f;

        public GameObject stingPrefab;
        public Transform firePoint;



        // Start is called before the first frame update
        void Start()
        {
          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        ///save all enemies in Range in an Array, <c>nearestEnemy</c> is the target
        void UpdateTarget()
        {
          ///while game is paused Enemy search is inactive. This should be unnecessary for game logic
          ///since the targets do not move during pause anyways, but it might save some processing power.
          if(!_gameManager.Paused)
          {
              GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
              float shortestDistance = Mathf.Infinity;
              GameObject nearestEnemy = null;

              //TODO Enemy selection based on distance of the enemy to the goal rather than the distance to the tower.
              foreach (GameObject enemy in enemies)
              {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                  shortestDistance = distanceToEnemy;
                  nearestEnemy = enemy;
                }
              }
              if (nearestEnemy != null && shortestDistance <= range)
              {
                target = nearestEnemy.transform;
              }
              else
              {
                target=null;
              }
          }
        }


        /// Update is called once per frame
        void Update()
        {
          /// DEBUG start/pause function
          if(Input.GetKeyDown(KeyCode.Space))
          {
              if(!_gameManager.Paused)
              {
                _gameManager.PauseGame();
                if(_gameManager.Paused)
                {
                  Debug.Log("Pause");
                }
              }
              else
              {
                _gameManager.StartGame();
                if(!_gameManager.Paused)
                {
                  Debug.Log("Start");
                }
              }
          }
          ///silence this method, while there is no enemy in Range
          if (target == null)
            return;
          ///while game is paused target tracking, <c>Shoot()</c> and <c>fireCountdown</c> are inactive
          if(!_gameManager.Paused)
          {
              ///Rotate the firepoint to the Position of the target
              ///3D Vector with the direction on Tower -> Target
              Vector3 dir = target.position - transform.position;
              ///Quaternion: Variable that manages rotation around all three axis.
              ///Mathematically it is a number system that extends real numbers with i, j and k instead just with the i(maginary part) of complex numbers.
              //Thus it forms the quotient of two vectors in three dimensional space.
              //The <c>Lerp</c> is only used to make the movement of the rotation smoother.
              Vector3 rotatedVectorDir = Quaternion.Euler(0,0,180)*dir;
              Quaternion lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
              Quaternion rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
              partToRotate.rotation = rotation;

              //shoot in given intervall
              if (fireCountdown <= 0f)
              {
                Shoot();
                fireCountdown = 1f / fireRate;
              }

              fireCountdown -= Time.deltaTime;
          }
        }

        void Shoot()
        {
          Debug.Log("shots fired"); ///debug
          GameObject stingGO = (GameObject)Instantiate (stingPrefab, firePoint.position, firePoint.rotation);
          Sting sting = stingGO.GetComponent<Sting>();
          if (sting != null)
          {
            sting.damage=towerDamage;
            sting.effect=towerEffect;
            sting.Seek(target);
          }
        }


        ///draw circle Sphere around the Tower to mark up the Range (in scene View only)
        void OnDrawGizmosSelected ()
        {
          Gizmos.color = Color.red;
          Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
