using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletpref,muzzle;
    public float firepause,firepauseval;
    // Start is called before the first frame update
    void Start()
    {
        firepause = firepauseval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && firepause<=0 )
        {
            firepause = firepauseval;
            Instantiate(bulletpref,muzzle.transform.position,transform.rotation);
            Camera.main.GetComponent<camerashake>().ShakeIt();
        }

        firepause -= Time.deltaTime;
    }
}
