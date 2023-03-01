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
    NPC_Class npcCurrentState;
    [SerializeField]GameObject questItem;








    private void Awake()
    {
        cineMachineCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();

        questGiver = GetComponent<QuestGiver>();
        npcCurrentState = GetComponent<NPC_Class>();
      
    }


    private void Update()
    {
        
            
        
    }

    public void NPCAction()
    {
        cineMachineCamera.Priority = 13;

        if (!npcCurrentState.isQuestDone && Quest_Class.instance.CurrentState == Quest_Class.QuestState.BeforeQuest && npcCurrentState.CurrentNpcState == NPC_Class.NpcState.NpcBeforeQuest && !Quest_Class.instance.isQuestActive)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON[0], cineMachineCamera, questGiver, npcCurrentState);
            questItem.SetActive(true);
        }
        else if (Quest_Class.instance.CurrentState == Quest_Class.QuestState.AmidQuest && npcCurrentState.CurrentNpcState == NPC_Class.NpcState.NpcAmidQuest)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON[1], cineMachineCamera, questGiver, npcCurrentState);
        }
        else if (Quest_Class.instance.CurrentState == Quest_Class.QuestState.QuestFetched && npcCurrentState.CurrentNpcState == NPC_Class.NpcState.NpcCompleteQuest)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON[2], cineMachineCamera, questGiver, npcCurrentState);
        }


        else if (Quest_Class.instance.isQuestActive && npcCurrentState.CurrentNpcState == NPC_Class.NpcState.NpcBeforeQuest)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON[4], cineMachineCamera, questGiver, npcCurrentState);

        }

        else if (npcCurrentState.isQuestDone)
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON[3], cineMachineCamera, questGiver, npcCurrentState);
        }


    }
}

      // cineMachineCamera.Priority = 8;
        

