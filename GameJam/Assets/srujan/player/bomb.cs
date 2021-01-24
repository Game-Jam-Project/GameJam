using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float time,range,speed;
    public bool explode;
  
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (explode == false)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (explode == true)
        {
            Camera.main.GetComponent<camerashake>().ShakeIt();
            time -= Time.deltaTime;
            transform.localScale = new Vector3(4,4,1);
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
           
        }

        if (time <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "player")
        {
            Physics2D.IgnoreCollision(collision.collider.GetComponent<BoxCollider2D>(),gameObject.GetComponent<CircleCollider2D>());
        }
        else
        {
            explode = true;
        }
    }
}
