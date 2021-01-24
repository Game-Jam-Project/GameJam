using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingminion : MonoBehaviour
{

    public GameObject player;
    public float speed = 5,range = 4;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(player.transform.position,transform.position)<range && active == false)
        {
            active = true;
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
