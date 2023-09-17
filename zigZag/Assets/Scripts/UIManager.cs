using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
	[SerializeField] TMP_Text HightscoreText;
	
	int HighScore;

    void Start()
    {
    	//PlayerPrefs.DeleteAll();
        HighScore = PlayerPrefs.GetInt("HighScore");
    	HightscoreText.text = "Best score : " + HighScore;
    }


    void Update()
    {
        
    }
    
    public void PlayButton()
    {
    	SceneManager.LoadScene("Game");
    }
    
   public void GoToshop()
   {
   	SceneManager.LoadScene("carShop");
   }
   
   public void Quit()
   {
   	Application.Quit();
   }
    

}
