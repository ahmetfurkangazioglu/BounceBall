using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Ball Operation")]
    [SerializeField] GameObject[] Balls;
    [SerializeField] GameObject BallPoint;
    [SerializeField] float ForcePower;
    int CurrentBall;
    [Header("Level Operation")]
    [SerializeField] int TotalBall;
    [SerializeField] int TargetAmount;
    [SerializeField] Slider LevelSlider;
    [SerializeField] TextMeshProUGUI TotalBallText;
    [HideInInspector] public int SuccessShot;
    bool ShotLocked;
    [Header("Effect Operation")]
    [SerializeField] ParticleSystem[] BallEfect;
    [SerializeField] ParticleSystem GunShotEffect;
    [SerializeField] Renderer TransParentBox;
    float BoxStartValue;
    float BoxStepValue;
    int CurrentEffect;
    [Header("Other Operation")]
    [SerializeField] GameObject[] GeneralPanel;
    [SerializeField] TextMeshProUGUI[] CurrentLevelText;
    int SceneIndex;
    string SceneName;
    void Start()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneName = SceneManager.GetActiveScene().name;
        BoxStartValue = 0.5f;
        Time.timeScale = 1;
        BoxStepValue = 0.25f / TargetAmount;
        LevelSlider.maxValue = TargetAmount;
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
            GunShotEffect.Play();
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
    public void GeneralOperations(string Value)
    {
        switch (Value)
        {
            case"Pause":
                Time.timeScale = 0;
                GeneralPanel[0].SetActive(true);
                break;
            case "Continue":
                Time.timeScale = 1;
                GeneralPanel[0].SetActive(false);
                break;
            case "Restart":
                SceneManager.LoadScene(SceneIndex);
                break;
            case "MainMenu":
                SceneManager.LoadScene(0);
                break;
            case "NextLevel":          
                 SceneManager.LoadScene(SceneIndex + 1);
                break;         
            case "Settings":
            //setting
                break;
        }
    }
    public void BallEffectOperation(Vector3 Poziton, Material NewMat)
    {
        BallEfect[CurrentEffect].transform.position = Poziton;
        BallEfect[CurrentEffect].GetComponent<ParticleSystemRenderer>().material = NewMat;
        BallEfect[CurrentEffect].gameObject.SetActive(true);
        if (CurrentEffect == BallEfect.Length - 1)
            CurrentEffect = 0;
        else
            CurrentEffect++;
    }
    private void WinCotrol()
    {
        SuccessShot++;
        LevelSlider.value = SuccessShot;
        BoxStartValue -= BoxStepValue;
        Debug.Log(BoxStartValue);
        TransParentBox.material.SetTextureScale("_MainTex", new Vector3(1f, BoxStartValue));
        if (SuccessShot== TargetAmount)
        {
            ShotLocked = true;
            CurrentLevelText[0].text = SceneName;
            GeneralPanel[1].SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void LoseControl()
    {
        int BallAmount = 0;
        foreach (var item in Balls)
        {
            if (item.activeInHierarchy)
            {
                BallAmount++;
            }
        }
        if (SuccessShot+TotalBall+BallAmount< TargetAmount)
        {
            ShotLocked = true;
            CurrentLevelText[1].text = SceneName;
            GeneralPanel[2].SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void BallShoot()
    {
        Balls[CurrentBall].transform.SetPositionAndRotation(BallPoint.transform.position, BallPoint.transform.rotation);
        Balls[CurrentBall].SetActive(true);
        Balls[CurrentBall].GetComponent<Rigidbody>().AddForce(Balls[CurrentBall].transform.TransformDirection(90, 90, 0) * ForcePower, ForceMode.Force);
    }
}
