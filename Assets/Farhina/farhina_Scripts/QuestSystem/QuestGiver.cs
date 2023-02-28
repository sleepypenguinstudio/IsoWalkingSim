using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // GiveQuest();
        }
    }


    public void GiveQuest()
    {
        Debug.Log("Quest");
        QuestManager questManager = FindObjectOfType<QuestManager>();


        if (questManager.quests.Count == 0 || questManager.quests[questManager.quests.Count - 1].isActive == false)
        {
            questManager.AddQuest(quest);
            QuestUIManager questUIManager = FindObjectOfType<QuestUIManager>();
            if (questUIManager != null)
            {
                questUIManager.DisplayQuest(quest);
            }

            Destroy(gameObject);

        }

        //  Destroy(gameObject);
    }
}
