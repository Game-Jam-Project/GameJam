using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilemovement : MonoBehaviour
{

    public Transform player;
    Vector2 dir,dir2;
    public float speed;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("player").transform;
        dir =player.position- transform.position;

        dir2 = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir2 * Time.deltaTime * speed);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }

   
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "player")
            {
                if (player.GetComponent<playerhealth>().phase == false)
                {
                    player.GetComponent<playerhealth>().health -= 1;
                    player.GetComponent<playerhealth>().phase = true;
                }

            }
        }
}
