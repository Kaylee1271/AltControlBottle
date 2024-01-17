using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_stay_open : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    int rotation_time = 300;

    public AudioSource scr_open;
    public AudioClip clp_open;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 2)
        {
            if (rotation_time > 0)
            {
                transform.Rotate(new Vector3(0, 0.5f, 0));
                if (rotation_time == 300) scr_open.PlayOneShot(clp_open);
                rotation_time--;

            }
        }
    }
}

