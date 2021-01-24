using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserdamage : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        
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
