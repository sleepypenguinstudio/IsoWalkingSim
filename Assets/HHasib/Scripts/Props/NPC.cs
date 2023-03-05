using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class NPC : MonoBehaviour, IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset[] inkJSON;
    [SerializeField] private TextAsset[] inkJSONMidQuest;
    [SerializeField]CinemachineVirtualCamera cineMachineCamera;
    [SerializeField] QuestGiver questGiver;
    [SerializeField] NPC_Class npcCurrentState;
    [SerializeField]GameObject questItem;
    [SerializeField]Animator npcAnimator;

    [SerializeField] bool isNonQuestNPC;






    private void Awake()
    {
        if (gameObject.GetComponentInChildren<CinemachineVirtualCamera>())
        {
            cineMachineCamera = gameObject.GetComponentInChildren<CinemachineVirtualCamera>();
        }
        if (gameObject.GetComponentInChildren<Animator>())
        {
            npcAnimator = gameObject.GetComponentInChildren<Animator>();
        }
        if (GetComponent<QuestGiver>()) {
            questGiver = GetComponent<QuestGiver>();
        }
        if (GetComponent<NPC_Class>()) {
            npcCurrentState = GetComponent<NPC_Class>();
        }
      
    }


    private void Update()
    {
        
            
        
    }

    public void NPCAction()
    {
        cineMachineCamera.Priority = 13;

        if (!isNonQuestNPC) {


            if (!npcCurrentState.isQuestDone && Quest_Class.instance.CurrentState == Quest_Class.QuestState.BeforeQuest && npcCurrentState.CurrentNpcState == NPC_Class.NpcState.NpcBeforeQuest && !Quest_Class.instance.isQuestActive)
            {
                DialogueManager.instance.EnterDialogueMode(inkJSON[0], cineMachineCamera, questGiver, npcCurrentState, npcAnimator,isNonQuestNPC);
                questItem.SetActive(true);
            }
            else if (Quest_Class.instance.CurrentState == Quest_Class.QuestState.AmidQuest && npcCurrentState.CurrentNpcState == NPC_Class.NpcState.NpcAmidQuest)
            {
                DialogueManager.instance.EnterDialogueMode(inkJSONMidQuest[Random.Range(0, 3)], cineMachineCamera, questGiver, npcCurrentState, npcAnimator, isNonQuestNPC);
            }
            else if (Quest_Class.instance.CurrentState == Quest_Class.QuestState.QuestFetched && npcCurrentState.CurrentNpcState == NPC_Class.NpcState.NpcCompleteQuest)
            {
                DialogueManager.instance.EnterDialogueMode(inkJSON[2], cineMachineCamera, questGiver, npcCurrentState, npcAnimator, isNonQuestNPC);
            }


            else if (Quest_Class.instance.isQuestActive && npcCurrentState.CurrentNpcState == NPC_Class.NpcState.NpcBeforeQuest)
            {
                DialogueManager.instance.EnterDialogueMode(inkJSON[4], cineMachineCamera, questGiver, npcCurrentState, npcAnimator, isNonQuestNPC);

            }

            else if (npcCurrentState.isQuestDone)
            {
                DialogueManager.instance.EnterDialogueMode(inkJSON[3], cineMachineCamera, questGiver, npcCurrentState, npcAnimator, isNonQuestNPC);
            }
        }
        else
        {

            DialogueManager.instance.EnterDialogueMode(inkJSON[0], cineMachineCamera, questGiver, npcCurrentState, npcAnimator, isNonQuestNPC);

            transform.gameObject.tag = "Finish";


        }

    }
}

      // cineMachineCamera.Priority = 8;
        

