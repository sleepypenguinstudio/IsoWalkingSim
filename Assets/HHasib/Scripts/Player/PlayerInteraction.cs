using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] float interactRange;
    public bool IsInteractable;
    PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        PlayerInputSystem.OnInteractionPressed += Interect;
    }

    private void OnDisable()
    {
        PlayerInputSystem.OnInteractionPressed -= Interect;
    }


    public void Interect()
    {
        
       Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider in colliderArray)
        {

            if (collider.CompareTag("NPC") && collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.NPCAction();
                playerMovement.LookTowards(collider.gameObject);
            }

            
            Debug.Log(collider);
        }

    }

    public bool InterectDetection()
    {
       
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {

            if (collider.CompareTag("NPC"))
            {
                return true;
            }

            
            
        }
        return false;
    }


}
