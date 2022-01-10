using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


namespace Backbone
{
    public class Sting : MonoBehaviour
    {
        private GameManager _gameManager;

        public Sting() {
          _gameManager = GameManager.GetInstance();
        }

        [Header("Hit Effects – given by Tower")]
        private int _damage;
        public int Damage
        {
          get {return _damage;}
          set {_damage = value;}
        }
        private string _effect;
        public string Effect
        {
          get {return _effect;}
          set {_effect = value;}
        }


        [Header("Attributes")]
        private float _speed = 20f;
        private float _pauseSpeed = 0f;
        private float _pauseEndSpeed = 20f;
        private float _turnSpeed = 100f;

        [Header("Unity Setup - Do not change!")]
        private Transform target;
        public GameObject impactEffect;
        Vector3 dirBackup;
        ///experimental, trying to Pause the particle System
        ///does not work and makes the whole script dysfunctional.
        ///[SerializeField] float timeScale = 1.0f;
        ///[SerializeField] VisualEffect VFX;

        ///<summary>
        ///Method called in <c>Tower </c> script
        ///On instantiating the <c> Sting </c> object, the <param name ="target"> Target </param> of the tower is passed to the Sting.
        ///</summary>
        public void Seek (Transform _target)
        {
          target = _target;
        }

        void Start()
        {
          ///VFX = GetComponent<VisualEffect>();
        }

        // Update is called once per frame
        ///<summary>
        ///Calculation of the direction of the Sting
        ///Also: Call of the <c> HitTarget() </c> method and Start/Pause Implementation
        ///</summary>
        void Update()
        {
          ///VFX.playRate = timeScale;
          if(!_gameManager.Paused)
          {
              _speed = _pauseEndSpeed;
              ///timeScale = 1.0f;
              if (target != null)
              {
                  ///rotate the Sting towards the target
                  Vector3 dir = target.position - transform.position;
                  dirBackup=dir;
                  Vector3 rotatedVectorDir = Quaternion.Euler(0,0,90)*dir;
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
              {   /// if the targets gets destroyed before hitting it, go on flying for 4 seconds before selfdestruct
                  float distanceThisFrame = _speed * Time.deltaTime;
                  transform.Translate(dirBackup.normalized * distanceThisFrame, Space.World);
                  Destroy(gameObject, 4f);
              }

            }
            else
            {
              _speed = _pauseSpeed;
              ///timeScale = 0f;
            }
        }

        ///<summary>
        ///Effects on the Sting on hitting a target: <c> impactEffect </c> and selfdestruction.
        ///</summary>
        void HitTarget()
        {
              Debug.Log("Hit: "+_damage+" damage dealt and "+_effect+" effect");
              GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
              Destroy(effectInstance, 2f);
              Destroy(gameObject);
        }

        ///<summary>
        ///if another collision should appear, <c>HitTarget</c> if it is a bird, selfdestruct otherwise.
        ///<param name ="collision"> collsion effect </param>
        ///</summary>
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
