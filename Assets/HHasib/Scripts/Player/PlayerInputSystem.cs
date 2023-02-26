using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayerInputSystem : MonoBehaviour
{

    public static event Action OnInteractionPressed;

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


        starterAssetInput.Player.Click.performed += Walk;
        starterAssetInput.Player.Click.Enable();

        starterAssetInput.Player.DoubleClick.performed += Run;
        starterAssetInput.Player.DoubleClick.Enable();

        starterAssetInput.Player.Interact.performed += InteractSystem;
        starterAssetInput.Player.Interact.Enable();

        

    }

    

    private void OnDisable()
    {
        starterAssetInput.Player.Click.Disable();
        starterAssetInput.Player.Disable();
        starterAssetInput.Player.Disable();
    }



    private void Walk(InputAction.CallbackContext context)
    {

        Vector2 mousePosition2D = Mouse.current.position.ReadValue();

        Vector3 mousePosition3D = new Vector3(mousePosition2D.x,mousePosition2D.y,0f);

       // thirdPersonController.Move(mousePosition3D);
        playerMovement.Movement(mousePosition3D,true);

        
    }



    private void Run(InputAction.CallbackContext context)
    {
        Vector2 mousePosition2D = Mouse.current.position.ReadValue();

        Vector3 mousePosition3D = new Vector3(mousePosition2D.x, mousePosition2D.y, 0f);

        // thirdPersonController.Move(mousePosition3D);
        playerMovement.Movement(mousePosition3D, false);
    }



    private void InteractSystem(InputAction.CallbackContext context)
    {


        OnInteractionPressed?.Invoke();

        Debug.Log("Pressed E");
    }

}
