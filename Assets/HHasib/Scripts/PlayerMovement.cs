using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera;

    [SerializeField] float playerSpeed = 2f;
    private RaycastHit rayCastHit;
    NavMeshAgent agent;
    private string groundTag = "Ground";



    //Animation

    [SerializeField] Animator animator;
    private bool hasAnimator;
    private int animIDSpeed;
    private int animIDMotionSpeed;
    private float animationBlend;
    public float SpeedChangeRate = 10f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       // agent.speed = playerSpeed;
        hasAnimator = TryGetComponent(out animator);
        AssignAnimationID();
    }

    private void Update()
    {
        hasAnimator = TryGetComponent(out animator);

        

    }


    public void Movement(Vector3 mousePosition)
    {

        animationBlend = Mathf.Lerp(animationBlend,playerSpeed,Time.deltaTime*SpeedChangeRate);
      
        Ray ray = camera.ScreenPointToRay(mousePosition);

        if(Physics.Raycast(ray,out rayCastHit, Mathf.Infinity))
        {
            if (rayCastHit.collider.CompareTag(groundTag)){


                agent.SetDestination(rayCastHit.point);

                
            }
        }





    }


    private void AssignAnimationID()
    {
        animIDSpeed = Animator.StringToHash("Speed");
        animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }

    void SetMoveAnimation(int animVlaue)
    {
        animator.SetFloat(animIDSpeed, animVlaue);
        animator.SetFloat(animIDMotionSpeed, animVlaue);
    }


}
