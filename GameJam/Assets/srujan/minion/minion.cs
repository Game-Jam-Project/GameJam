using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion : MonoBehaviour
{
    public float range,speed,start;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position.x;
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right*Time.deltaTime*speed);
        if (transform.position.x > start + range)
        {
            transform.eulerAngles=new Vector3(0,-180,0);
        }

        if (transform.position.x < start)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player" && player.GetComponent<playerhealth>().phase == false)
        {
            player.GetComponent<playerhealth>().health -= 1;
            player.GetComponent<playerhealth>().phase = true;
        }
    }
}
