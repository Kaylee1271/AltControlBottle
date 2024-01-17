using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    bool moving = false;
    float timer = 1;
    public Transform[] checkpoints;
    public int checkpoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;

    public Animator animator;

    public AudioSource source;
    public AudioClip music;


    void Start()
    {
        animator.speed = 0;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    void Awake()
    {
        source.volume = 0.1f;
        source.PlayOneShot(music, 1);
    }


    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("running"))
        {
            agent.destination = checkpoints[checkpoint].position;
        }
        else agent.destination = transform.position;


        if (Input.GetKeyDown("space")) moving = true;

        if (moving == true)
        {

            timer -= Time.deltaTime;
        }
        else timer = 1f;

        if (timer < 0)
        {
            animator.speed = 1;
            animator.SetBool("is_moving", true);
        }
        else animator.SetBool("is_moving", false);
    }

    void OnTriggerEnter(Collider other)
    {
        checkpoint++;
        if (other.tag.Equals("Finish")) moving = false;
    }
}
