using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

     public ThirdPersonController PersonController ;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void InteractWithNPC(NPCController npc)
    {
        npc.Interact();
        Debug.Log("Interacting with NPC");
    }

    public void InteractWithBall(BallController ball)
    {
        // Do something when interacting with a ball
        Debug.Log("Interacting with ball");
    }
}
