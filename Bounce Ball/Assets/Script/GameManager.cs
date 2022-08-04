using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Ball Operation")]
    [SerializeField] GameObject[] Balls;
    [SerializeField]  GameObject BallPoint;
    [SerializeField] float ForcePower;
    int CurrentBall;
    [Header("Level Operation")]
    [SerializeField] int TotalBall;
    [SerializeField] int TargerAmount;
    [SerializeField] Slider LevelSlider;
    [SerializeField] TextMeshProUGUI TotalBallText;
    [HideInInspector] public int SuccessShot;
    bool ShotLocked;
    void Start()
    {
        LevelSlider.maxValue = TargerAmount;
        TotalBallText.text = TotalBall.ToString();
    }
    void Update()
    {
        if (TotalBall==0)
        {
            ShotLocked = true;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& !ShotLocked)
        {
            TotalBall--;
            TotalBallText.text = TotalBall.ToString();
            BallShoot();
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

    public void GameResult(string Value)
    {
        switch (Value)
        {
            case "Success":            
                WinCotrol();
                break;
            case "Fail":
                LoseControl();
                break;
        }
    }

    void WinCotrol()
    {
        SuccessShot++;
        LevelSlider.value = SuccessShot;
        if (SuccessShot==TargerAmount)
        {
            ShotLocked = true;
            Debug.Log("Win");
        }
    }
    void LoseControl()
    {
        if (SuccessShot+TotalBall<TargerAmount)
        {
            ShotLocked = true;
            Debug.Log("Lose");
        }
    }
    void BallShoot()
    {
        Balls[CurrentBall].transform.SetPositionAndRotation(BallPoint.transform.position, BallPoint.transform.rotation);
        Balls[CurrentBall].SetActive(true);
        Balls[CurrentBall].GetComponent<Rigidbody>().AddForce(Balls[CurrentBall].transform.TransformDirection(90, 90, 0) * ForcePower, ForceMode.Force);
    }
}
