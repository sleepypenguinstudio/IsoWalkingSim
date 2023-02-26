using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public float ballSpeed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        ballSpeed = Random.Range(3f, 7f);
        Vector3 direction = new Vector3(Random.Range(-0.2f, 0.2f), 0, 1);
        rb.AddForce(direction * ballSpeed, ForceMode.Impulse);
        Invoke("DestroyBall", 5f);
    }

    private void DestroyBall()
    {
        Destroy(this.gameObject);
    }

}
