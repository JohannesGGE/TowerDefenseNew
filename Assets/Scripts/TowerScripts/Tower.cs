using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class Tower : MonoBehaviour
    {
        private GameManager _gameManager;

        public Tower()
        {
            _gameManager = GameManager.GetInstance();
        }

        private Transform target;

        [Header("Hit Effects")]
        private int _towerDamage = 0;

        public int TowerDamage
        {
          get {return _towerDamage;}
          protected set {_towerDamage = value;}
        }

        private string _towerEffect = "none";

        public string TowerEffect
        {
          get {return _towerEffect;}
          protected set {_towerEffect = value;}
        }

        private float _iceDuration = 0;

        public float IceDuration
        {
          get {return _iceDuration;}
          protected set {_iceDuration = value;}
        }

        private float _iceDelay = 0;

        public float IceDelay
        {
          get {return _iceDelay;}
          protected set {_iceDelay = value;}
        }



        [Header("Attributes")]
        private float _range = 5f;

        public float Range
        {
          get {return _range;}
          protected set {_range = value;}
        }

        private float _fireRate = 1f;

        public float FireRate
        {
          get {return _fireRate;}
          protected set {_fireRate = value;}
        }

        private float _fireCountdown = 0f;

        public float FireCountdown
        {
          get {return _fireCountdown;}
          protected set {_fireCountdown = value;}
        }

        [Header("Unity Setup - Do not change!")]
        public readonly string enemyTag = "Bird";
        private float _turnSpeed = 10f;

        ///To make these private I have to assign their values (Objects/Prefabs) within the Script
        ///Not via the drag and drop functionality of the Unity GUI
        ///I can not figure out, if and how that would be possible
        public Transform PartToRotate;
        public Transform FirePoint;
        public GameObject StingPrefab;




        // Start is called before the first frame update
        void Start()
        {
          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        ///<summary>
        ///save all enemies in Range in an Array, <c>nearestEnemy</c> is the target
        ///</summary>
        void UpdateTarget()
        {
          ///while game is paused Enemy search is inactive. This should be unnecessary for game logic
          ///since the targets do not move during pause anyways, but it might save some processing power.
          if(!_gameManager.Paused)
          {
              GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
              ///float shortestDistance = Mathf.Infinity;
              ///GameObject nearestEnemy = null;

              //Enemy selection based on distance of the enemy to the goal rather than the distance to the tower.
              float longestWay = 0;
              GameObject farthestEnemy = null;
              foreach (GameObject enemy in enemies)
              {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                float way = enemy.GetComponent<BirdMovement>().dist;
                if (way >= longestWay && distanceToEnemy <= _range)
                  {
                    longestWay = way;
                    farthestEnemy = enemy;
                  }

                  if (farthestEnemy != null)
                  {
                    target = farthestEnemy.transform;
                  }
                  else
                  {
                    target = null;
                  }
              }



              /// Enemy selection based on Distance to Tower
              /*
              foreach (GameObject enemy in enemies)
              {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                  shortestDistance = distanceToEnemy;
                  nearestEnemy = enemy;
                }
              }
              if (nearestEnemy != null && shortestDistance <= _range)
              {
                target = nearestEnemy.transform;
              }
              else
              {
                target=null;
              }
              */
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

          ///Upgrade
          if(Input.GetKeyDown(KeyCode.U))
          {
            Upgrade();
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
              Quaternion rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * _turnSpeed);
              PartToRotate.rotation = rotation;

              //shoot in given intervall
              if (_fireCountdown <= 0f)
              {
                Shoot();
                _fireCountdown = 1f / _fireRate;
              }

              _fireCountdown -= Time.deltaTime;
          }
        }

        ///<summary>
        ///instantiate Sting Object and set it's values <c>_damage </c> and <c>_effect </c>
        ///according to the towers abilities
        ///</summary>
        void Shoot()
        {
          Debug.Log("shots fired"); ///debug
          GameObject stingGO = (GameObject)Instantiate (StingPrefab, FirePoint.position, FirePoint.rotation);
          Sting sting = stingGO.GetComponent<Sting>();
          if (sting != null)
          {
            sting.Damage=_towerDamage;
            sting.Effect=_towerEffect;
            sting.Seek(target);
          }
        }

        ///<summary>
        ///draw circle Sphere around the Tower to mark up the Range (in scene View only)
        ///</summary>
        void OnDrawGizmosSelected ()
        {
          Gizmos.color = Color.red;
          Gizmos.DrawWireSphere(transform.position, _range);
        }

        ///<summary>
        ///Upgrade functionality, defined within the subclasses. Virtual keyword enables override
        ///</summary>
        protected virtual void Upgrade()
        {
          return;
        }

        ///<summary>
        ///helper for <c> Upgrade() </c> method
        ///</summary>
        protected void DestroyScriptInstance()
        {
          Destroy(this);
        }
    }
}
