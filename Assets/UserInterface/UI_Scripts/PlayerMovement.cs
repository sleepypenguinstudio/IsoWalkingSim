using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed =10f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;


    private QuestManager questManager;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
           questManager = FindObjectOfType<QuestManager>();
        
    }

    void Update()
    {

        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            Debug.Log(move);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

            //Quest newQuest = new Quest("New Quest", "Description of new quest", new List<string> { "Objective 1", "Objective 2" }, 100);
            //questManager.AddQuest(newQuest);
           
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

      
    }
}
