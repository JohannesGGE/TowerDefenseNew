using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


namespace Backbone
{
    public class Sting : MonoBehaviour
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instatiating the GameManager class
        /// </summary>
        private GameManager _gameManager;

        /// <summary>
        /// Constructor <c>Sting</c> constructs a Sting Instance refering to the GameManager Instance
        /// </summary>
        public Sting()
        {
          _gameManager = GameManager.GetInstance();
        }

        [Header("Hit Effects – given by Tower")]

        /// <summary>
        /// Variable <c>_damage</c> carries the damage defined by Tower type
        /// </summary>
        private int _damage;

        /// <summary>
        /// Getters and Setters <c>Damage</c> for <c>_damage</c>
        /// </summary>
        public int Damage
        {
          get {return _damage;}
          set {_damage = value;}
        }

        /// <summary>
        /// Variable <c>_effect</c> carries the effect defined by Tower type
        /// </summary>
        private string _effect;

        /// <summary>
        /// Getters and Setters <c>Effect</c> for <c>_effect</c>
        /// </summary>
        public string Effect
        {
          get {return _effect;}
          set {_effect = value;}
        }

        /// <summary>
        /// Variable <c>_iceDurationSting</c> passed on by <c>Tower</c>
        /// </summary>
        private float _iceDurationSting = 0;

        /// <summary>
        /// Getters and Setters <c>IceDurationSting</c> for <c>_iceDurationSting</c>
        /// </summary>
        public float IceDurationSting
        {
          get {return _iceDurationSting;}
          set {_iceDurationSting = value;}
        }

        /// <summary>
        /// Variable <c>_iceDuration</c> passed on by <c>Tower</c>
        /// </summary>
        private float _iceDelaySting = 0;

        /// <summary>
        /// Getters and Setters <c>IceDelaySting</c> for <c>_iceDelaySting</c>
        /// </summary>
        public float IceDelaySting
        {
          get {return _iceDelaySting;}
          set {_iceDelaySting = value;}
        }


        [Header("Attributes")]
        /// <summary>
        /// Variable <c>stingTag</c> given by Tower
        /// </summary>
        private string _stingTag = "Basic";

        public string StingTag
        {
          get {return _stingTag;}
          set {_stingTag = value;}
        }


        /// <summary>
        /// Variable <c>_speed</c> defines movement speed of projectile
        /// </summary>
        private float _speed = 20f;

        /// <summary>
        /// Variable <c>_pauseSpeed</c> defines movement speed of projectile while paused
        /// </summary>
        private float _pauseSpeed = 0f;

        /// <summary>
        /// Variable <c>_pauseEndSpeed</c> defines movement speed of projectile when pause ends
        /// </summary>
        private float _pauseEndSpeed = 5f;

        /// <summary>
        /// Variable <c>_turnSpeed</c> defines turning speed of projectile
        /// </summary>
        private float _turnSpeed = 100f;

        [Header("Unity Setup - Do not change!")]

        /// <summary>
        /// Variable <c>target</c> contains the current target handed over by the shooting <c>Tower</c>
        /// </summary>
        private Transform target;

        /// <summary>
        /// Variable <c>impactEffect</c> contains the Component of Sting that produces the fragmenting effect
        /// </summary>
        public GameObject impactEffect;

        /// <summary>
        /// Variable <c>dirBackup</c> saves the direction of a Sting before the target gets destroyed
        /// </summary>
        Vector3 dirBackup;
        //experimental, trying to Pause the particle System
        //does not work and makes the whole script dysfunctional.
        //[SerializeField] float timeScale = 1.0f;
        //[SerializeField] VisualEffect VFX;

        ///<summary>
        ///Function <c>Seek()</c> called by <c>Tower</c> when instantiation this <c>Sting</c> object
        ///</summary>
        ///<param name ="target">Target</param>
        public void Seek (Transform _target)
        {
          target = _target;
        }

        //not in use right now
        void Start()
        {
          //VFX = GetComponent<VisualEffect>();
        }

        // Update is called once per frame
        ///<summary>
        ///Function <c>Update()</c> calculates the direction of the Sting
        ///Also: Call of the <c>HitTarget()</c> method and Start/Pause Implementation
        ///</summary>
        void Update()
        {
          //VFX.playRate = timeScale;
          if(!_gameManager.Paused)
          {
              _speed = _pauseEndSpeed;
              //timeScale = 1.0f;
              if (target != null)
              {
                  //rotate the Sting towards the target
                  Vector3 dir = target.position - transform.position;
                  dirBackup=dir;
                  Vector3 rotatedVectorDir = Quaternion.Euler(0,0,-90)*dir;
                  Quaternion lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
                  Quaternion rotation = Quaternion.Lerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
                  gameObject.transform.rotation = rotation;
                  float distanceThisFrame = _speed * Time.deltaTime;

                  if (dir.magnitude <= distanceThisFrame)
                  {
                    HitTarget();
                    return;
                  }
                  transform.Translate(dir.normalized * distanceThisFrame, Space.World);
              }
              else
              {   //if the targets gets destroyed before hitting it, go on flying for 4 seconds before selfdestruct
                  float distanceThisFrame = _speed * Time.deltaTime;
                  transform.Translate(dirBackup.normalized * distanceThisFrame, Space.World);
                  Destroy(gameObject, 4f);
              }

            }
            else
            {
              _speed = _pauseSpeed;
              //timeScale = 0f;
            }
        }

        ///<summary>
        ///Function <c>HitTarget()</c>: Effects on the Sting on hitting a target: <c>impactEffect</c> and selfdestruction.
        ///</summary>
        void HitTarget()
        {
              Debug.Log("Hit: "+_damage+" damage dealt and "+_effect+" effect");
              GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);

              //Calling effect methods in Enemy Script

              if (target.GetComponent<Enemy>() != null)
              {
                  target.GetComponent<Enemy>().TakeDamage(_damage);

                  if (_effect=="fire")
                  {target.GetComponent<Enemy>().TakeFire(_damage, 3, 1);}

                  if (_effect=="ice")
                  {target.GetComponent<Enemy>().TakeSlow(_iceDelaySting,_iceDurationSting);}
              }

              Destroy(effectInstance, 2f);
              Destroy(gameObject);
        }

        ///<summary>
        ///Function <c>OnCollisionEnter2D()</c>if another collision should appear: <c>HitTarget</c> if it is a bird, selfdestruct otherwise.
        ///</summary>
        ///<param name ="collision"> collsion effect </param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
          if(collision.gameObject.tag=="Bird")
          {
            HitTarget();
          }
          else
          {
            Destroy(gameObject);
          }
        }

    }
}
