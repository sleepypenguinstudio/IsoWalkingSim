using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
   
    Quest_Class.QuestState currentState;
    bool isQuestActive;


    bool oldLadyQuestDone;
    NPC_Class.NpcState oldLadyCurrentState;

    bool singleMomQuestDone;
    NPC_Class.NpcState singleMomCurrentState;


    bool rockStarQuestDone;
    NPC_Class.NpcState rockStarCurrentState;

    


    
    




    public  PlayerData(NPC.NPC_Name npc,bool isQuestDone,NPC_Class.NpcState npcState)
    {

        isQuestActive = Quest_Class.instance.isQuestActive;
        currentState = Quest_Class.instance.CurrentState;

        switch (npc)
        {
            case NPC.NPC_Name.Fuli:
                singleMomQuestDone = isQuestDone;
                singleMomCurrentState = npcState;
                break;
            case NPC.NPC_Name.OldLady:
                oldLadyQuestDone = isQuestDone;
                oldLadyCurrentState = npcState;
                break;
            case NPC.NPC_Name.RockStar:
                rockStarQuestDone = isQuestDone;
                rockStarCurrentState = npcState;
                break;
          
        }



    }



}
