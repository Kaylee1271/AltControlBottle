using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights_out : MonoBehaviour
{
    public GameObject player;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<movement>().checkpoint > 9 && Input.GetKeyDown("space")) GameObject.Destroy(self);
    }
}
