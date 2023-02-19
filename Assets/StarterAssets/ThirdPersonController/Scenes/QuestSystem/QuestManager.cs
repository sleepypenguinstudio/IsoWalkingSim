using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    public QuestUI questUI;

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
 questUI.AddQuestUI(quest);
    Debug.Log("g");
        
    }

    public void UpdateQuest(string questName, string objective)
    {
        foreach (Quest quest in quests)
        {
            if (quest.questName == questName)
            {
                quest.objectives.Remove(objective);
            }
        }
    }
}
