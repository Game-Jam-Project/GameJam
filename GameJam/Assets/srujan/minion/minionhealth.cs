using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionhealth : MonoBehaviour
{
    public int health;
    public GameObject[] bombs;
    public bool phase;
    public float time, timeval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("bomb") != null)
        {
            bombs = GameObject.FindGameObjectsWithTag("bomb");
        }
        if (health <= 0)
        {
            Object.Destroy(this.gameObject);
        }
        for (int i = 0; i < bombs.Length; i++)
        {
            if (Vector2.Distance(transform.position, bombs[i].transform.position) < bombs[i].GetComponent<bomb>().range && bombs[i].GetComponent<bomb>().explode == true)
            {
                health -= 3;
            }
        }

        if (phase == true)
        {
            time -= Time.deltaTime; 
        }

        if (time <= 0)
        {
            phase = false;
            time = timeval;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            health--;
            Object.Destroy(collision.gameObject);
       
        }
    }
}
