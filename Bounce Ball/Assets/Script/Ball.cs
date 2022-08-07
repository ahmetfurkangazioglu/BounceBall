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
            BallOperation("Fail", "Fail");
        }
        else if (other.CompareTag("BoxPoint"))
        {
            BallOperation("Box", "Success");
        }     
    }

    void BallOperation(string sound,string Result)
    {
        Sound.SoundOperation(sound);
        Manager.GameResult(Result);
        Manager.BallEffectOperation(gameObject.transform.position, NewMat);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
