using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    bool moving = false;
    public Transform[] checkpoints;
    private int checkpoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;

    public AudioSource source;
    public AudioClip music;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    void Awake()
    {
        source.PlayOneShot(music, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving == true) agent.destination = checkpoints[checkpoint].position;
        else agent.destination = transform.position;
        //Debug.Log(moving);

        if (Input.GetKeyDown("space")) moving = true;
    }

    void OnTriggerEnter(Collider other)
    {
        checkpoint++;
        //Debug.Log("colission");
        moving = false;
    }
}
