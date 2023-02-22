using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    public BoxCollider boxCollider;
   


    //    void OnTriggerEnter(Collider other)
    //    {
    //       
    //    }
    //    void OnTriggerExit(Collider other)
    //    {
    //        if (other.gameObject.CompareTag("Player"))
    //        {
    //            objectToActivate.SetActive(false);
    //        }
    //    }
    public bool IsInteractable { get; set; }

    private void Start()
    {
        IsInteractable = true;
    }

   


    public void Interact()
    {
       
        objectToActivate.SetActive(true);
       
      

    }
   
}
