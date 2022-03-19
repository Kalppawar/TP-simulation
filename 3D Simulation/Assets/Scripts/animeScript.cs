using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animeScript : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    bool isSitting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
        }
        if ( !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) )
        {
            animator.SetBool("isWalking", false);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("isSitting", isSitting);
            isSitting ^= true;
        }
    }
}
