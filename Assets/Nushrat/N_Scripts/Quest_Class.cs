using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Class : MonoBehaviour
{
    public enum QuestState
    {
        BeforeQuest,
        AmidQuest,
        QuestComplete,
        AfterQuest
    }

    public QuestState currentState;

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
