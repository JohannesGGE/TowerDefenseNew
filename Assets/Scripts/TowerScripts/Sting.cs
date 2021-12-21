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

        private Transform target;

        public float speed = 40f;
        public float turnSpeed = 100f;
        public GameObject impactEffect;

        public void Seek (Transform _target)
        {
          target = _target;
        }

        // Update is called once per frame
        void Update()
        {
          if(!_gameManager.Paused)
          {
                  //Do movement

              if (target == null)
              {
                Destroy(gameObject);
                return;
              }
              ///rotate the Sting towards the target
              Vector3 dir = target.position - transform.position;
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
        }
        void HitTarget()
        {
          Debug.Log("Hit");
          GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
          Destroy(effectInstance, 2f);
          Destroy(gameObject);
        }

    }
}
