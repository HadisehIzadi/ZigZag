using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
	[SerializeField] TMP_Text HightscoreText;
	[SerializeField] GameObject mainPanlePanel;
	[SerializeField] GameObject aboutusPanel;
	[SerializeField] GameObject settingsPanel;
	
	[SerializeField] SettingsManager settingManager;

	
	int HighScore;

    void Start()
    {

        
        
    	//PlayerPrefs.DeleteAll();
    	if(PlayerPrefs.GetInt("sounds") == 1)
    		settingManager.EnableSounds();
    	else
    		settingManager.DisableSounds();
    
    	mainPanlePanel.SetActive(true);
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
   
   public void Aboutus()
   {
   	mainPanlePanel.SetActive(false);
   	aboutusPanel.SetActive(true);
   }
   
   
   public void BackAboutus()
   {
   	mainPanlePanel.SetActive(true);
   	aboutusPanel.SetActive(false);
   }
   
   public void setting()
   {
   	mainPanlePanel.SetActive(false);
   	settingsPanel.SetActive(true);
   }
   
   
   public void BackSetting()
   {
   	mainPanlePanel.SetActive(true);
   	settingsPanel.SetActive(false);
   }

}
