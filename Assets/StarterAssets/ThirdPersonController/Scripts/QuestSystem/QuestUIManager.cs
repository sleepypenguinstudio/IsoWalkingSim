using Mono.Cecil.Cil;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    public TMP_Text questTitleText;

    public Image iconImage;

    private bool isDisplayingTitle = true;

    public void DisplayQuest(Quest quest)
    {
        questTitleText.text = quest.questTitle;

        iconImage.sprite = quest.icon;

    }

    public void ChangeDisplayText()
    {
        isDisplayingTitle = !isDisplayingTitle;
        if (isDisplayingTitle)
        {
            questTitleText.text ="complete";
            iconImage.gameObject.SetActive(true);


        }
        else
        {
            questTitleText.text = "complete";
            iconImage.gameObject.SetActive(false);
        }
        

    }
}

