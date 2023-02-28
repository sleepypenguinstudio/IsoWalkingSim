using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Class : MonoBehaviour
{
    public enum QuestState
    {
        BeforeQuest,
        AmidQuest,
        QuestFetched,
        QuestComplete,
        AfterQuest,
        
    }

    public QuestState currentState;
    public bool isQuestActive = false;

    // NpcState;
    public static Quest_Class instance;

    private void Awake()
    {
        currentState = QuestState.BeforeQuest;

        if (instance != null)
        {
            Debug.LogWarning("Found more than one Quest Manager in the scene");
        }
        instance = this;

    }

    


}
