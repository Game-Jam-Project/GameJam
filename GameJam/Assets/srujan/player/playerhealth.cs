using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    public bool phase;
    public int health;
    public float time, timeval;
    public Color col;
    // Start is called before the first frame update
    void Start()
    {
        time = timeval;
        col = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == true)
        {
            time -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(col.r,col.g,col.b,0.5f);
            
        }
        if (time <= 0)
        {
            phase = false;
            GetComponent<SpriteRenderer>().color = new Color(col.r, col.g, col.b, 1);


            time = timeval;
        }
    }
}
