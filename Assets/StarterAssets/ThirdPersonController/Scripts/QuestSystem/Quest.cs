using UnityEngine;
using UnityEngine.UI;





[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{

    public bool isActive = false;

    public string questTitle;
    
    public Sprite  icon;


    public void Complete()
    {
        isActive = false;
       
    }



}
