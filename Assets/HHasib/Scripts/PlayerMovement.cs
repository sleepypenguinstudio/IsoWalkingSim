using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera;

   
    private RaycastHit rayCastHit;
    public NavMeshAgent agent;
    private string groundTag = "Ground";

    CharacterController controller;


    //Player

    public float walkSpeed=4;
    public float RunSpeed=8;

    //Animation

    [SerializeField] Animator animator;
    
    private int animIDSpeed;
    private int animIDMotionSpeed;

    //Audio

    public AudioClip[] FootStepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        AssignAnimationID();
    }

    private void Update()
    {


        SetMoveAnimation(agent.velocity.magnitude,2);
        

    }


    public void Movement(Vector3 mousePosition,bool isWalking)
    {
        agent.speed = isWalking ? walkSpeed : RunSpeed;



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

    void SetMoveAnimation(float animVlaue,int animMotionVlaue)
    {
        animator.SetFloat(animIDSpeed, animVlaue);
        animator.SetFloat(animIDMotionSpeed, animMotionVlaue);
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootStepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootStepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootStepAudioClips[index], transform.TransformPoint(controller.center), FootstepAudioVolume);
            }
        }
    }











}
