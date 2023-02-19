using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemUI : MonoBehaviour
{
    public TMP_Text questName;
    public TMP_Text questDescription;
    public TMP_Text objectives;
    public TMP_Text reward;

    public void UpdateUI(Quest quest)
    {
        questName.text = quest.questName;
        questDescription.text = quest.questDescription;
        objectives.text = "Objectives: " + string.Join(", ", quest.objectives.ToArray());
        reward.text = "Reward: " + quest.questReward;
    }

    public void UpdateObjectiveUI(string objective)
    {
        objectives.text = "Objectives: " + string.Join(", ", objective);
    }
}

