using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour,IInteractable
{
    public void NPCAction()
    {


        Destroy(this.gameObject);


    }
}
