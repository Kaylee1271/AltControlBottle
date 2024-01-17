using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haunt : MonoBehaviour
{
    bool has_haunted = false;
    float haunting = 0;
    public GameObject player;
    public Animator animator;
    public GameObject mesh;
    // Start is called before the first frame update
    void Start()
    {
        animator.speed = 0;
        mesh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<movement>().checkpoint > 5)
        {
            if (!has_haunted && Input.GetKeyDown("space"))
            {
                haunting = 6;
                has_haunted = true;
                animator.speed = 0.5f;
            }
        }
        haunting -= Time.deltaTime;

        if (haunting > 3 && haunting < 6) transform.Translate(new Vector3(-Time.deltaTime*2,0,0));
        if (haunting > 0 && haunting < 3) transform.Translate(new Vector3( Time.deltaTime*2, 0, 0));
    }
}
