using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Balls;
    public GameObject BallPoint;
    int CurrentBall;
    public float ForcePower;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Balls[CurrentBall].transform.SetPositionAndRotation(BallPoint.transform.position, BallPoint.transform.rotation);
            Balls[CurrentBall].SetActive(true);
            Balls[CurrentBall].GetComponent<Rigidbody>().AddForce(Balls[CurrentBall].transform.TransformDirection(90, 90, 0) * ForcePower, ForceMode.Force);
            if (CurrentBall == Balls.Length-1)
            {
                CurrentBall = 0;
            }
            else
            {
                CurrentBall++;
            }
        }
    }
}
