using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager Manager;
    public VoicesManager Sound;
    Rigidbody rb;
    Material NewMat;
    void Start()
    {
        NewMat = GetComponent<MeshRenderer>().material;   
        rb = GetComponent<Rigidbody>();   
    }
    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("PlatformBounce"))
        {
            Sound.SoundOperation("Platform");            
        }
        else if (collision.gameObject.CompareTag("WoodBounce"))
        {
            Sound.SoundOperation("Wood");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            Sound.SoundOperation("Fail");
            Manager.BallEffectOperation(gameObject.transform.position, NewMat);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            Manager.GameResult("Fail");
        }
        else if (other.CompareTag("BoxPoint"))
        {
            Sound.SoundOperation("Box");
            Manager.BallEffectOperation(gameObject.transform.position, NewMat);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            Manager.GameResult("Success");
        }     
    }
}
