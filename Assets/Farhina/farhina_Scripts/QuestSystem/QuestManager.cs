using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    public void AddQuest(Quest quest)
    {



        if (!quests.Contains(quest))
        {
            quests.Add(quest);
            quest.isActive = true;

        }
    }


    public void RemoveQuest(Quest quest)
    {
        if (quests.Contains(quest))
        {
            quests.Remove(quest);
        }
    }

    public void CompleteQuest()
    {


        Quest activeQuest = quests.Find(q => q.isActive);
        if (activeQuest != null)
        {
            activeQuest.Complete();
        }


    }
}