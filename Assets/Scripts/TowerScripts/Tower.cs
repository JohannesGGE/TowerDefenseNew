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
          GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
          float shortestDistance = Mathf.Infinity;
          GameObject nearestEnemy = null;

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


        // Update is called once per frame
        void Update()
        {
          ///silence this method, while there is no enemy in Range
          if (target == null)
            return;

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

          if (fireCountdown <= 0f)
          {
            Shoot();
            fireCountdown = 1f / fireRate;
          }

          fireCountdown -= Time.deltaTime;

        }

        void Shoot()
        {
          Debug.Log("shots fired"); ///debug
          GameObject stingGO = (GameObject)Instantiate (stingPrefab, firePoint.position, firePoint.rotation);
          Sting sting = stingGO.GetComponent<Sting>();
          if (sting != null)
          {
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
