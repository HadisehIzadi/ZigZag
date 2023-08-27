using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	[Header("Elements")]
	public static GameManager instance;
	public bool gameStarted;
	public GameObject platformSpawner;
	
	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    
   public void GameOver()
    {
    	gameStarted = false;
    	platformSpawner.SetActive(false);
    	
    	Invoke("ReloadScene" , 1f);
    }
   
   void ReloadScene()
   {
   	SceneManager.LoadScene("Game");
   }
}
