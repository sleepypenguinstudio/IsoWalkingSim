using System.Collections;
using UnityEngine;

public class GuardTreeController : MonoBehaviour
{
    public Animator animator;
    string floatParameterName = "Blend";
    float floatIncrement = 0.1f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    


}
