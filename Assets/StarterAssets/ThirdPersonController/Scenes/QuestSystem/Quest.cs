using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public string questDescription;
    public List<string> objectives;
    public int questReward;

    public Quest(string name, string description, List<string> obj, int reward)
    {
        questName = name;
        questDescription = description;
        objectives = obj;
        questReward = reward;
    }
}
