using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager Manager;
    Rigidbody rb;
    Material NewMat;
    void Start()
    {
        NewMat = GetComponent<MeshRenderer>().material;   
        rb = GetComponent<Rigidbody>();   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            Manager.BallEffectOperation(gameObject.transform.position, NewMat);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            Manager.GameResult("Fail");
        }
        else if (other.CompareTag("BoxPoint"))
        {
            Manager.BallEffectOperation(gameObject.transform.position, NewMat);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            Manager.GameResult("Success");
        }
    }
}
