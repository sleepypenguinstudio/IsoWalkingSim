using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class NPC : MonoBehaviour, IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset[] inkJSON;
    CinemachineVirtualCamera cineMachineCamera;
    [SerializeField] QuestGiver questGiver;








    private void Awake()
    {
        cineMachineCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();

        questGiver = GetComponent<QuestGiver>();
    }

    public void NPCAction()
    {
        cineMachineCamera.Priority = 13;

        if (Quest_Class.instance.currentState == Quest_Class.QuestState.BeforeQuest && !Quest_Class.instance.isQuestActive)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON[0], cineMachineCamera, questGiver);
        }
        else if (Quest_Class.instance.currentState == Quest_Class.QuestState.AmidQuest)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON[1], cineMachineCamera, questGiver);
        }

        else if (Quest_Class.instance.currentState == Quest_Class.QuestState.QuestComplete)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON[1], cineMachineCamera, questGiver);
        }
        else if (Quest_Class.instance.currentState == Quest_Class.QuestState.AfterQuest)
        {

        }

    }
}

      // cineMachineCamera.Priority = 8;
        

