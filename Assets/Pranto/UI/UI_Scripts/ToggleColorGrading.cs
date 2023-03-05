using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;


public class ToggleColorGrading : MonoBehaviour
{


    private Volume postProcessVolume;

    void Start()
    {
        postProcessVolume = GetComponent<Volume>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ColorAdjustments colorAdjustments;
            Debug.Log("gg");
            if (postProcessVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
            {
                colorAdjustments.saturation.overrideState = !colorAdjustments.saturation.overrideState;
                colorAdjustments.saturation.value = colorAdjustments.saturation.overrideState ? 0 : -100;
            }
        }
    }
}
