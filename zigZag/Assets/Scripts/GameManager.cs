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
	//public TMP_Text HightscoreText;
	public TMP_Text diamondText;
	public GameObject gameplayUI;
	public GameObject mainMenuPanel;
	
	[SerializeField] GameObject[] Cars;
	
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
    	
    	//PlayerPrefs.SetInt("HighScore" , 1000);

    	HighScore = PlayerPrefs.GetInt("HighScore");
    	//HightscoreText.text = "Best score : " + HighScore;
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
    	
    	StopCoroutine("updateScore");
    	saveHighScore();
    	Invoke("ReloadScene" , 0.5f);
    	
    }
   
   void ReloadScene()
   {
   	SceneManager.LoadScene("Intro");
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
   
   public void GoToshop()
   {
   	SceneManager.LoadScene("carShop");
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
