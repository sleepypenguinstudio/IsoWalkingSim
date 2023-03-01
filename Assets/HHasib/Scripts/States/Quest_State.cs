using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_State : MonoBehaviour
{

    public enum QuestState
    {
        BeforeQuest,
        AmidQuest,
        AfterQuest
    }


    public static Quest_State instance;

    public QuestState currentQuestState;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
