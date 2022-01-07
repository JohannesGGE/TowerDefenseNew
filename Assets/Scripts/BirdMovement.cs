using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class BirdMovement : MonoBehaviour
    {
        private GameManager _gameManager;

        public BirdMovement()
        {
            _gameManager = GameManager.GetInstance();
        }

        Rigidbody2D rb;
        // Start is called before the first frame update

        void Start()
        {
            Debug.Log("Start");
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
          if (!_gameManager.Paused)
          {
              rb.velocity = Vector3.right*3f;

          }
          else
          {
              rb.velocity = Vector3.right*0f;
          }
          ///DEBUG tool
          if(Input.GetKeyDown(KeyCode.D))
          {
            Destroy(gameObject);
          }
        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
          if(collision.gameObject.tag=="Tower")
          {
            Destroy(gameObject);
            Destroy(collision.gameObject);
          }
        }
    }
}
