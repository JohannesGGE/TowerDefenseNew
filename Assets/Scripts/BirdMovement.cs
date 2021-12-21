using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{

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
      rb.velocity = Vector3.right*3f;

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
