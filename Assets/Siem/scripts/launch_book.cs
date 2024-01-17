using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_book : MonoBehaviour
{
    bool has_launched = false;
    Rigidbody rb;
    public GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))  
        {
            if (has_launched == false)
            {
                has_launched = true;
                rb.AddForce(new Vector3(100*(player.transform.position.x-transform.position.x), 0, 100*(player.transform.position.z - transform.position.z)));
            }
        }
    }
}
