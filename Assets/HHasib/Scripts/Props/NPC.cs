using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class NPC : MonoBehaviour,IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    CinemachineVirtualCamera cineMachineCamera;
    
    private void Awake()
    {
        cineMachineCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    public void NPCAction()
    {
        cineMachineCamera.Priority = 13;

        DialogueManager.instance.EnterDialogueMode(inkJSON,cineMachineCamera);

      // cineMachineCamera.Priority = 8;
        

    } 
}
