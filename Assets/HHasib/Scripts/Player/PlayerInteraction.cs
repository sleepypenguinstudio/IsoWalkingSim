using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] float interactRange;
    public bool IsInteractable;


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

            if (collider.CompareTag("Props") && collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.PropsAction();
            }

            
            Debug.Log(collider);
        }

    }

    public bool InterectDetection()
    {
       
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {

            if (collider.CompareTag("Props"))
            {
                return true;
            }

            
            
        }
        return false;
    }


}
