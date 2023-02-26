using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string questTitle;
    
    public Sprite  icon;

}
