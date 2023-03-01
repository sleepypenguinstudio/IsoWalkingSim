using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] float interactRange;

    private void Update()
    {

        Physics.OverlapSphere(transform.position, interactRange);
    }
}
