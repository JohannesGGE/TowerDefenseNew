using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class Tower : MonoBehaviour
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instantiating the GameManager class
        /// </summary>
        protected GameManager _gameManager;

        /// <summary>
        /// Constructor <c>Tower</c> constructs a Tower Instance refering to the GameManager Instance
        /// </summary>
        public Tower()
        {
            _gameManager = GameManager.GetInstance();
        }

        /// <summary>
        /// Variable <c>target</c> contains the current target of a tower
        /// </summary>
        private Transform target;

        [Header("Hit Effects")]

        /// <summary>
        /// Variable <c>_towerDamage</c> is declared in <c>Tower</c>, but defined by the subclasses
        /// </summary>
        private int _towerDamage = 0;

        /// <summary>
        /// Getters and Setters <c>TowerDamage</c> for <c>_towerDamage</c>
        /// </summary>
        public int TowerDamage
        {
          get {return _towerDamage;}
          protected set {_towerDamage = value;}
        }

        /// <summary>
        /// Variable <c>_towerEffect</c> is declared in <c>Tower</c>, but defined by the subclasses
        /// </summary>
        private string _towerEffect = "none";

        /// <summary>
        /// Getters and Setters <c>TowerEffect</c> for <c>_towerEffect</c>
        /// </summary>
        public string TowerEffect
        {
          get {return _towerEffect;}
          protected set {_towerEffect = value;}
        }

        /// <summary>
        /// Variable <c>_iceDuration</c> is declared in <c>Tower</c>, but defined by the subclasses <c>IceTower</c>
        /// </summary>
        private float _iceDuration = 0;

        /// <summary>
        /// Getters and Setters <c>IceDuration</c> for <c>_iceDuration</c>
        /// </summary>
        public float IceDuration
        {
          get {return _iceDuration;}
          protected set {_iceDuration = value;}
        }

        /// <summary>
        /// Variable <c>_iceDuration</c> is declared in <c>Tower</c>, but defined by the subclasses <c>IceTower</c>
        /// </summary>
        private float _iceDelay = 0;

        /// <summary>
        /// Getters and Setters <c>IceDelay</c> for <c>_iceDelay</c>
        /// </summary>
        public float IceDelay
        {
          get {return _iceDelay;}
          protected set {_iceDelay = value;}
        }



        [Header("Attributes")]
        /// <summary>
        /// Variable <c>_range</c> is declared in <c>Tower</c>, but defined by the subclasses
        /// </summary>
        private float _range;

        /// <summary>
        /// Getters and Setters <c>Range</c> for <c>_range</c>
        /// </summary>
        public float Range
        {
          get {return _range;}
          protected set {_range = value;}
        }

        /// <summary>
        /// Variable <c>_fireRate</c> is declared in <c>Tower</c>, but defined by the subclasses
        /// </summary>
        private float _fireRate;

        /// <summary>
        /// Getters and Setters <c>FireRate</c> for <c>_fireRate</c>
        /// </summary>
        public float FireRate
        {
          get {return _fireRate;}
          protected set {_fireRate = value;}
        }

        /// <summary>
        /// Variable <c>_fireCountdown</c> is declared in <c>Tower</c>, but defined by the subclasses
        /// </summary>
        private float _fireCountdown = 0f;

        /// <summary>
        /// Getters and Setters <c>FireCountdown</c> for <c>fireCountdown</c>
        /// </summary>
        public float FireCountdown
        {
          get {return _fireCountdown;}
          protected set {_fireCountdown = value;}
        }

        /// <summary>
        /// Variable <c>_stage</c> is declared in <c>Tower</c>, but defined by the subclasses
        /// </summary>
        private string _stage;

        /// <summary>
        /// Getters and Setters <c>Stage</c> for <c>_stage</c>
        /// </summary>
        public string Stage
        {
          get {return _stage;}
          protected set {_stage = value;}
        }

        /// <summary>
        /// Variable <c>_upgradeCost</c> is declared in <c>Tower</c>, but defined by the subclasses
        /// </summary>
        private int _upgradeCost;

        /// <summary>
        /// Getters and Setters <c>UpgradeCost</c> for <c>_upgradeCost</c>
        /// </summary>
        public int UpgradeCost
        {
          get {return _upgradeCost;}
          protected set {_upgradeCost = value;}
        }

        /// <summary>
        /// Variable <c>_price</c> is declared in <c>Tower</c>, but defined by the subclasses
        /// </summary>
        private int _price;

        /// <summary>
        /// Getters and Setters <c>UpgradeCost</c> for <c>_price</c>
        /// </summary>
        public int Price
        {
          get {return _price;}
          protected set {_price = value;}
        }


        [Header("Unity Setup - Do not change!")]
        /// <summary>
        /// Variable <c>enemyTag</c> is defined in <c>Tower</c> and readonly aka final
        /// </summary>
        public readonly string enemyTag = "Bird";

        /// <summary>
        /// Variable <c>_turnSpeed</c> is defined in <c>Tower</c>
        /// </summary>
        private float _turnSpeed = GameValues.TowerTurnSpeed;



        /// <summary>
        /// Variable <c>FirePoint</c> refers to the child Object <c>firePoint</c>of the Tower prefab
        /// </summary>
        public Transform FirePoint;

        /// <summary>
        /// Variable <c>PartToRotate</c> refers to the child Object <c>firePoint</c>of the Tower prefab
        /// </summary>
        public Transform PartToRotate;

        /// <summary>
        /// Variable <c>StingPrefab</c> refers to the the Sting prefab
        /// </summary>
        public GameObject StingPrefab;
        //To make these private I have to assign their values (Objects/Prefabs) within the Script
        //Not via the drag and drop functionality of the Unity GUI
        //I can not figure out, if and how that would be possible


        protected bool chosen = false;

        /// <summary>
        /// Called before the first Frame, invokes the <c>UpdateTarget()</c> function
        /// </summary>
        void Start()
        {
          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        ///<summary>
        ///save all enemies in Range in an Array, <c>farthestEnemy</c> is the target
        ///</summary>
        void UpdateTarget()
        {
              GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

              //Enemy selection based on distance of the enemy to the goal rather than the distance to the tower.
              float longestWay = 0;
              GameObject farthestEnemy = null;
              foreach (GameObject enemy in enemies)
              {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                float way = enemy.GetComponent<Enemy>().Dist;
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
        }


        // Update is called once per frame
        //Rotation of the <c>Tower</c> towards the <c>target</c>
        //call of the <c>Upgrade()</c> and the <c>Shoot()</c> methods
        //Start/Pause functionality TODO change the Pause trigger from pressen 'Space' Key to GUI trigger
        ///<summary>
        ///Function <c>Update()</c> tracks <c>Target</c> and shoots at it
        ///</summary>
        void Update()
        {
          //silence this method, while there is no enemy in Range
          if (target == null)
            return;
          //while game is paused target tracking, <c>Shoot()</c> and <c>fireCountdown</c> are inactive
          // if(!_gameManager.Paused)
          // {
              //Rotate the firepoint to the Position of the target
              //3D Vector with the direction on Tower -> Target
              Vector3 dir = target.position - transform.position;
              //Quaternion: Variable that manages rotation around all three axis.
              //Mathematically it is a number system that extends real numbers with i, j and k instead just with the i(maginary part) of complex numbers.
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
          // }
        }

        //TODO include IceTower abilities here and in Sting script
        ///<summary>
        ///Function <c>Shoot()</c> Instantiates Sting Object and sets it's values <c>_damage </c> and <c>_effect </c> according to the towers abilities
        ///</summary>
        void Shoot()
        {
          //Debug.Log("shots fired"); //debug
          GameObject stingGO = (GameObject)Instantiate (StingPrefab, FirePoint.position, FirePoint.rotation);
          Sting sting = stingGO.GetComponent<Sting>();
          if (sting != null)
          {
            if(_towerEffect=="ice")
            {
              sting.StingTag="Ice";
            }
            if(_towerEffect=="fire")
            {
              sting.StingTag="Fire";
            }
            sting.Damage=_towerDamage;
            sting.Effect=_towerEffect;
            sting.IceDelaySting=_iceDelay;
            sting.IceDurationSting=_iceDuration;
            sting.Seek(target);
          }
        }

        ///<summary>
        ///Function <c>OnDrawGizmosSelected()</c> Draws circle Sphere around the Tower to marks up the Range (in scene View only)
        ///</summary>
        void OnDrawGizmosSelected()
        {
          Gizmos.color = Color.red;
          Gizmos.DrawWireSphere(transform.position, _range);
        }

        //The current <c>Tower</c> script gets swapped with the next one e.g. <c>BasicTower1</c> -> <c>BasicTower2</c>
        //TODO: change trigger from pressing Key 'D' to GUI trigger
        ///<summary>
        ///Function <c>Upgrade()</c>: Upgrade functionality, defined within the subclasses. Virtual keyword enables override
        ///</summary>
        public virtual void Upgrade()
        {
          Debug.Log("empty method");
          return;
        }

        ///<summary>
        ///Function <c>DestroyScriptInstance()</c>Helper for <c> Upgrade()</c> method
        ///</summary>
        protected void DestroyScriptInstance()
        {
          Destroy(this);
        }
    }
}
