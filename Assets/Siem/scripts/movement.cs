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
    public AudioSource scream;
    public AudioSource wilhelm;
    public AudioSource light;

    bool has_screamed = false;


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


        if (Input.GetKeyDown("space"))
        {
            moving = true;
            if (checkpoint > 8) light.Play();
        }

        if (moving == true)
        {

            timer -= Time.deltaTime;
        }
        else timer = 0.8f;

        if (timer < 0)
        {
            animator.speed = 1;
            animator.SetBool("is_moving", true);
            if (!has_screamed)
            {
                if (checkpoint > 8) wilhelm.Play();
                else scream.Play();
            }
            has_screamed = true;
        }
        else
        {
            animator.SetBool("is_moving", false);
            has_screamed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        checkpoint++;
        if (other.tag.Equals("Finish")) moving = false;
    }
}
