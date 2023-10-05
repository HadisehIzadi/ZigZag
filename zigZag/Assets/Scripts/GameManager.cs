using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	[Header("Elements")]
	public static GameManager instance;
	public bool gameStarted;
	[SerializeField] GameObject platformSpawner;
	[SerializeField] TMP_Text scoreText;
	[SerializeField] TMP_Text GameOverscoreText;
	[SerializeField] TMP_Text HightscoreText;
	//public TMP_Text HightscoreText;
	[SerializeField] TMP_Text diamondText;
	[SerializeField] GameObject gameplayUI;
	[SerializeField] GameObject mainMenuPanel;
	[SerializeField] GameObject gameOverPanel;
	[SerializeField] GameObject[] Cars;
	[SerializeField] Camera mainCamera;
	[SerializeField] AdManager adManager;
	[Header("Audios")]
	AudioSource audioSource;
	public AudioClip[] gameMusics;
	
	int score;
	int HighScore;
	int diamonds;
	
	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
		
		audioSource = GetComponent<AudioSource>();
	}
    // Start is called before the first frame update
    void Start()
    {
    	SetSelectedcar();
    	CollerChanger collorChanger = mainCamera.GetComponent<CollerChanger>();
    	collorChanger.enabled = true;
    	//PlayerPrefs.SetInt("HighScore" , 1000);

    	HighScore = PlayerPrefs.GetInt("HighScore");
    	//HightscoreText.text = "Best score : " + HighScore;
    	adManager.Request();
    }

    // Update is called once per frame
    void Update()
    {
    	if(!gameStarted)
    	{
    		if(Input.GetMouseButtonDown(0))
    			StartGame();
    	}
    	
    	diamonds = PlayerPrefs.GetInt("diamondCount");
   		diamondText.text = diamonds.ToString();
    }
    

    
   public void StartGame()
    {
    	gameStarted = true;
    	platformSpawner.SetActive(true);
    	gameplayUI.SetActive(true);
    	mainMenuPanel.SetActive(false);
    	
//    	audioSource.clip = gameMusics[1];
//    	audioSource.Play();

    	
   		
    	StartCoroutine("updateScore");
    }
    
   public void GameOver()
    {
    	gameStarted = false;
    	
    	platformSpawner.SetActive(false);
    	scoreText.gameObject.SetActive(false);
    	
    	CollerChanger collorChanger = mainCamera.GetComponent<CollerChanger>();
    	collorChanger.enabled = false;
    	GameOverscoreText.text = score.ToString();
    	StopCoroutine("updateScore");
    	saveHighScore();
    	gameOverPanel.SetActive(true);
    	HighScore = PlayerPrefs.GetInt("HighScore");
    	HightscoreText.text = "Best score : " + HighScore;
    	//Time.timeScale = 0f;
    	//Invoke("ReloadScene" , 0.5f);
    	
    }
   
   public void ReloadScene()
   {
   	SceneManager.LoadScene("Game");
   }
   
   IEnumerator updateScore()
   {
   	while(true)
   	{
   		yield return new WaitForSeconds(1f);
   		score++;
   		scoreText.text = score.ToString();
   		
   		
   	}
   }
   
   
   void saveHighScore()
   {
   	if(PlayerPrefs.HasKey("HighScore"))
   	{
   		if(score >PlayerPrefs.GetInt("HighScore"))
   		{
   			PlayerPrefs.SetInt("HighScore" , score);
   		}
   	}
   	
   	else
   	{
   		PlayerPrefs.SetInt("HighScore" , score);
   	}
   }
   
   
   public void IncreamentScore()
   {
   	audioSource.PlayOneShot(gameMusics[2] , 0.1f);
   	score += 2;
   	scoreText.text = score.ToString();
   }
   
   public void playscaledSound()
   {
   	audioSource.PlayOneShot(gameMusics[3] , 0.2f);
   }
   
   public void GoToshop()
   {
   	SceneManager.LoadScene("carShop");
   }
   
   public void GoToMainMenue()
   {
   	SceneManager.LoadScene("Intro");
   }
   
   public void Resume()
   {
   	
   }
   
   void SetSelectedcar()
   {
   	PlayerPrefs.GetInt("selectedCar" , 0);
   	
   	if(PlayerPrefs.GetInt("selectedCar") == 0){
   		Cars[0].SetActive(true);
   		return;}
   	
   	for(int i = 0 ; i < Cars.Length ; i++)
   		Cars[i].SetActive(false);
   	
   		Cars[PlayerPrefs.GetInt("selectedCar") - 1].SetActive(true);
   		
   }
}
