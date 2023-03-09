using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class TimelineManager : MonoBehaviour
{

    [SerializeField] PlayableDirector playableDirector;

    private void Update()
    {
        if (playableDirector.state != PlayState.Playing)
        {
            SceneManager.LoadScene(1);


        }
    }
}
