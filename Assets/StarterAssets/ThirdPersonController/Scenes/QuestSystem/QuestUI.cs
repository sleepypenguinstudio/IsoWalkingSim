using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public GameObject questItemPrefab;
    public Transform questListContainer;

    public void AddQuestUI(Quest quest)
    {
        GameObject questItem = Instantiate(questItemPrefab, questListContainer);
        QuestItemUI questItemUI = questItem.GetComponent<QuestItemUI>();
        questItemUI.UpdateUI(quest);
    }
}
