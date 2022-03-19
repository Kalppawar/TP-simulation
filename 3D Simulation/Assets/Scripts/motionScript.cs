using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    CharacterController controller;

    [SerializeField]
    public Transform cam;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    float playerSpeed;
    private float jumpHeight = 1.1f;
    private float gravityValue = -9.81f;
    private float turnSmoothTime = 0.01f;
    private float temp;
    [SerializeField]
    Transform positioner;
    private bool inPosition = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        inPosition = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inPosition=false;
    }
    // Update is called once per frame
    void Update()
    {   
        if (inPosition && player.GetComponent<Animator>().GetBool("isSitting"))
        {
            controller.enabled = false;
            controller.transform.position = new Vector3(positioner.position.x, positioner.position.y, positioner.position.z);
            controller.transform.rotation = positioner.rotation;
            controller.enabled=true;
        }
        if (player.GetComponent<Animator>().GetBool("isSitting") )
        {
            return;
        }
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")).normalized;

        //controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        
        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref temp, turnSmoothTime);
            player.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
