using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Backbone
{
    public class Sting : MonoBehaviour
    {
        private GameManager _gameManager;

        public Sting() {
          _gameManager = GameManager.GetInstance();
        }


        [Header("Attributes")]
        public float speed = 20f;
        public float turnSpeed = 100f;

        [Header("Unity Setup - Do not change!")]
        private Transform target;
        public GameObject impactEffect;
        Vector3 dirBackup;

        public void Seek (Transform _target)
        {
          target = _target;
        }

        // Update is called once per frame
        void Update()
        {
          if(!_gameManager.Paused)
          {

              if (target != null)
              {
                  ///rotate the Sting towards the target
                  Vector3 dir = target.position - transform.position;
                  dirBackup=dir;
                  Vector3 rotatedVectorDir = Quaternion.Euler(0,0,90)*dir;
                  Quaternion lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
                  Quaternion rotation = Quaternion.Lerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
                  gameObject.transform.rotation = rotation;
                  float distanceThisFrame = speed * Time.deltaTime;

                  if (dir.magnitude <= distanceThisFrame)
                  {
                    HitTarget();
                    return;
                  }
                  transform.Translate(dir.normalized * distanceThisFrame, Space.World);
              }
              else
              {   ///go on flying for 4 seconds before selfdestruct
                  float distanceThisFrame = speed * Time.deltaTime;
                  transform.Translate(dirBackup.normalized * distanceThisFrame, Space.World);
                  Destroy(gameObject, 4f);
              }

            }
            else
            {
              speed = 0f;
            }
        }
        void HitTarget()
        {
          Debug.Log("Hit");
          GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
          Destroy(effectInstance, 2f);
          Destroy(gameObject);
        }

        ///if another collision should appear, <c>HitTarget</c> if it is a bird, selfdestruct otherwise.
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
