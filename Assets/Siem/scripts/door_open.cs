using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_open : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 1){
            transform.Rotate(new Vector3(0, 0.5f, 0));
        }
        if (transform.rotation.y > 0) {
            if (Vector3.Distance(player.position, transform.position) > 3.5f){
                transform.Rotate(new Vector3(0, -0.5f, 0));
            }
        }
    }
}
