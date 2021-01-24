using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstboss : MonoBehaviour
{
    public GameObject projectile;
    public float time, timeval,interval,intervalval,bullets;
    // Start is called before the first frame update
    void Start()
    {
        time = timeval;
        interval = intervalval;
    }

    // Update is called once per frame
    void Update()
    {
       if(bullets <= 0)
        {
            interval = intervalval;
            bullets = 3;
        }
        interval -= Time.deltaTime;

        if (interval <= 0)
        {
            time-= Time.deltaTime;
        }

        if (time <= 0)
        {
            Instantiate(projectile,transform.position,Quaternion.identity);
            time = timeval;
            bullets--;
        }
    }
}
