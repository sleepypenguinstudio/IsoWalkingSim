using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public QuestItemUI QuestItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestManager questManager = FindObjectOfType<QuestManager>();


            if (questManager.quests.Count==0 || questManager.quests[questManager.quests.Count - 1].isActive == false )
            {
                    questManager.AddQuest(quest);
                    QuestUIManager questUIManager = FindObjectOfType<QuestUIManager>();
                    if (questUIManager != null)
                    {
                        questUIManager.DisplayQuest(quest);
                    }

                Destroy(gameObject);

            }


            
        }

       }
    }



