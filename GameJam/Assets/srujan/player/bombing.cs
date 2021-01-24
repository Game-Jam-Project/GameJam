using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombing : MonoBehaviour
{
    public GameObject bomb, bombpref,muzzle;
    public float time, timeval,upthrust;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && time <= 0)
        {
           time = timeval;
           bomb = Instantiate(bombpref, muzzle.transform.position, transform.rotation);
            bomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,upthrust),ForceMode2D.Impulse);
        }
        time -= Time.deltaTime;
    }
}
