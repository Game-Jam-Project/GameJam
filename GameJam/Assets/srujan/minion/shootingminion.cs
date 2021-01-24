using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingminion : MonoBehaviour
{
    public GameObject player,projectile;
    public float interval, intervalval, range;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;

        if (Vector2.Distance(player.transform.position, transform.position) <= range)
        {
            if (interval <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                interval = intervalval;
            }
        }
        else
        {
            interval = intervalval;
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
