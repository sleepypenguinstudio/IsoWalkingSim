using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Props : MonoBehaviour,IInteractable
{

    CinemachineVirtualCamera cineMachineCamera;
    
    private void Awake()
    {
        cineMachineCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    public void PropsAction()
    {
        cineMachineCamera.Priority = 13;
        

        Destroy(this.gameObject,5);

    } 
}
