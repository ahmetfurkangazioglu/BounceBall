using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadScene(string Value)
    {
        switch (Value)
        {
            case"Play":
                int random = Random.Range(1, 4);
                SceneManager.LoadScene(random);
                break;
            case "Level1":          
                SceneManager.LoadScene(1);
                break;
            case "Level2":
                SceneManager.LoadScene(2);
                break;
            case "Level3":
                SceneManager.LoadScene(3);
                break;

        }
    }
    
}
