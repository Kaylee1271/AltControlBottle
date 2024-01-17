using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haunt : MonoBehaviour
{
    bool has_haunted = false;
    float haunting = 0;
    public GameObject player;
    public Animator animator;
    public MeshRenderer mesh;

    public AudioSource source;
    public AudioClip boe;
    // Start is called before the first frame update
    void Start()
    {
        animator.speed = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //mesh.enabled = false;

        if (player.GetComponent<movement>().checkpoint > 5)
        {
            if (!has_haunted && Input.GetKeyDown("space"))
            {
                haunting = 8;
                has_haunted = true;
                animator.speed = 0.4f;
                source.Play();
            }
        }
        haunting -= Time.deltaTime;

        if (haunting > 5 && haunting < 8) transform.Translate(new Vector3(0,Time.deltaTime,0));
        if (haunting > 0 && haunting < 3) transform.Translate(new Vector3(0, -Time.deltaTime, 0));
    }
}
