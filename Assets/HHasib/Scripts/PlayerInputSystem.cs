using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayerInputSystem : MonoBehaviour
{



    StarterAssetsInput starterAssetInput;
    PlayerMovement playerMovement;

    ThirdPersonController thirdPersonController;

   


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }



    private void OnEnable()
    {

        starterAssetInput = new StarterAssetsInput();
        starterAssetInput.Player.Enable();


        starterAssetInput.Player.Click.performed += SetClick;
        starterAssetInput.Player.Click.Enable();



    }

    private void OnDisable()
    {
        starterAssetInput.Player.Click.Disable();
        starterAssetInput.Player.Disable();
    }



    private void SetClick(InputAction.CallbackContext context)
    {

        Vector2 mousePosition2D = Mouse.current.position.ReadValue();

        Vector3 mousePosition3D = new Vector3(mousePosition2D.x,mousePosition2D.y,0f);

       // thirdPersonController.Move(mousePosition3D);
        playerMovement.Movement(mousePosition3D);

        Debug.Log("Old"+ Input.mousePosition);
        Debug.Log("New"+ mousePosition3D);
    }


}
