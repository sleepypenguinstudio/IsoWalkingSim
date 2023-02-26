using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemUI : MonoBehaviour
{
    public TMP_Text questTitleText;

    public Image iconImage;

    public void UpdateUI(Quest quest)
    {
        questTitleText.text = quest.questTitle;

        iconImage.sprite = quest.icon;
    }
}
