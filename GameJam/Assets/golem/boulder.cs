using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour
{
    public int force,min,max;
    public float upthrust,time;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        force = Random.Range(min, max+1);
        player = GameObject.Find("player");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-force,upthrust),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Object.Destroy(this.gameObject);
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
