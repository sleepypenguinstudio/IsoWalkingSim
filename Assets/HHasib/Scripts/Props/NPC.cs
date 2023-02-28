using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class NPC : MonoBehaviour,IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    CinemachineVirtualCamera cineMachineCamera;
    [SerializeField] QuestGiver questGiver;
    
    private void Awake()
    {
        cineMachineCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
       // questGiver = GetComponent<QuestGiver>();
    }

    public void NPCAction()
    {
        cineMachineCamera.Priority = 13;
        
        DialogueManager.instance.EnterDialogueMode(inkJSON,cineMachineCamera,questGiver);

      // cineMachineCamera.Priority = 8;
        

    } 
}
