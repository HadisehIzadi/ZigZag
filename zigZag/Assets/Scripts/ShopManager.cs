using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
	int diamonds;
	
	[Header("CAR 1")]
	[SerializeField] GameObject car1Canvas;
	[SerializeField] int car1amount;
//	[SerializeField] Button Buycar1Button;
	[SerializeField] Button useCar1;
	
	[Header("CAR 2")]
	[SerializeField] GameObject car2Canvas;
	[SerializeField] int car2amount;
	[SerializeField] Button Buycar2Button;
	[SerializeField] Button useCar2;
	
	[Header("CAR 3")]
	[SerializeField] GameObject car3Canvas;
	[SerializeField] int car3amount;
	[SerializeField] Button Buycar3Button;
	[SerializeField] Button useCar3;
	
	[SerializeField] GameObject selectedText;
    // Start is called before the first frame update
    void Start()
    {
    	
    	car1Canvas.SetActive(true);
    	
//    	if(PlayerPrefs.GetInt("car1sold") != 1) // hasnt bought car1 yet
//    	{
//    		Buycar1Button.interactable = true;
//    		useCar1.interactable = false;
//    	}
//    	
//    	else
//    	{
//     		Buycar1Button.interactable = false;
//    		useCar1.interactable = true;
//    	}
    	
    	
    	if(PlayerPrefs.GetInt("car2sold") != 1) // hasnt bought car2 yet
    	{
    		Buycar2Button.interactable = true;
    		useCar2.interactable = false;
    	}
    	
    	else
    	{
    		Buycar2Button.interactable = false;
    		useCar2.interactable = true;
    	}
    	
    	//**************** car 3 ********************************
    	 if(PlayerPrefs.GetInt("car3sold") != 1) // hasnt bought car3 yet
    	{
    		Buycar3Button.interactable = true;
    		useCar3.interactable = false;
    	}
    	
    	else
    	{
    		Buycar3Button.interactable = false;
    		useCar3.interactable = true;
    	}
    	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //***********************************************
    public void BackToGame()
    {
    	SceneManager.LoadScene("Intro");
    }
    
    void ShowText()
    {
    	selectedText.SetActive(true);
    	Invoke("HideText" , 0.6f);
    }
    
    void HideText()
    {
    	selectedText.SetActive(false);
    }
    
    //************** car 1 atribuites *****************
    public void Car1Next()
    {
    	car1Canvas.SetActive(false);
    	car2Canvas.SetActive(true);
    }
    
    
    public void SelectCar1()
    {
    	PlayerPrefs.SetInt("selectedCar" , 1);
    	Debug.Log("selected car : " + PlayerPrefs.GetInt("selectedCar"));
    	ShowText();
    	//SceneManager.LoadScene("Intro");
    }
    
    
    
    //************** car 2 atribuites *****************
    public void Car2Next()
    {
    	car2Canvas.SetActive(false);
    	car3Canvas.SetActive(true);
    }

	public void car2Back()
	{
		car1Canvas.SetActive(true);
		car2Canvas.SetActive(false);
	}
    
    public void Buycar2()
    {
    //	Debug.Log("high score : " + PlayerPrefs.GetInt("HighScore"));
    	if(car2amount  <= PlayerPrefs.GetInt("diamondCount"))
    	{
    		useCar2.interactable = true;
    		Buycar2Button.interactable = false;
    		PlayerPrefs.SetInt("car2sold" , 1);
    		diamonds = PlayerPrefs.GetInt("diamondCount") - car2amount;
    		PlayerPrefs.SetInt("diamondCount" , diamonds);
    		
    	}
    }
    
    public void SelectCar2()
    {
    	PlayerPrefs.SetInt("selectedCar" , 2);
    	Debug.Log("selected car : " + PlayerPrefs.GetInt("selectedCar"));
    	ShowText();
    	//SceneManager.LoadScene("Intro");
    }
    
    
    
    //************** car 2 atribuites *****************
//    public void Car2Next()
//    {
//    	car2Canvas.SetActive(false);
//    	car3Canvas.SetActive(true);
//    }

	public void car3Back()
	{
		car2Canvas.SetActive(true);
		car3Canvas.SetActive(false);
	}
    
    public void Buycar3()
    {
    	//Debug.Log("high score : " + PlayerPrefs.GetInt("diamondCount"));
    	
    	if(car3amount  <= PlayerPrefs.GetInt("diamondCount"))
    	{
    		useCar3.interactable = true;
    		Buycar3Button.interactable = false;
    		PlayerPrefs.SetInt("car3sold" , 1);
    		diamonds = PlayerPrefs.GetInt("diamondCount") - car3amount;
    		PlayerPrefs.SetInt("diamondCount" , diamonds);
    		
    	}
    }
    
    public void SelectCar3()
    {
    	PlayerPrefs.SetInt("selectedCar" , 3);
    	Debug.Log("selected car : " + PlayerPrefs.GetInt("selectedCar"));
    	ShowText();
    	
    	//SceneManager.LoadScene("Intro");
    }
}
