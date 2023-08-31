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
	public GameObject platformSpawner;
	public TMP_Text scoreText;
	public TMP_Text HightscoreText;
	public GameObject gameplayUI;
	public GameObject mainMenuPanel;
	
	[Header("Audios")]
	AudioSource audioSource;
	public AudioClip[] gameMusics;
	
	int score;
	int HighScore;
	
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
    	HighScore = PlayerPrefs.GetInt("HighScore");
    	HightscoreText.text = "Best score : " + HighScore;
    }

    // Update is called once per frame
    void Update()
    {
    	if(!gameStarted)
    	{
    		if(Input.GetMouseButtonDown(0))
    			StartGame();
    	}
    }
    

    
   public void StartGame()
    {
    	gameStarted = true;
    	platformSpawner.SetActive(true);
    	gameplayUI.SetActive(true);
    	mainMenuPanel.SetActive(false);
    	
    	audioSource.clip = gameMusics[1];
    	audioSource.Play();
    	
    	StartCoroutine("updateScore");
    }
    
   public void GameOver()
    {
    	gameStarted = false;
    	platformSpawner.SetActive(false);
    	
    	StopCoroutine("updateScore");
    	saveHighScore();
    	Invoke("ReloadScene" , 1f);
    	
    }
   
   void ReloadScene()
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
   	audioSource.PlayOneShot(gameMusics[2] , 0.2f);
   	score += 2;
   	scoreText.text = score.ToString();
   }
}
