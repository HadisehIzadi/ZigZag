using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
	
	
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
	
	
	[Header("CAR 4")]
	[SerializeField] GameObject car4Canvas;
	[SerializeField] int car4amount;
	[SerializeField] Button Buycar4Button;
	[SerializeField] Button useCar4;
	
	[Header("CAR 5")]
	[SerializeField] GameObject car5Canvas;
	[SerializeField] int car5amount;
	[SerializeField] Button Buycar5Button;
	[SerializeField] Button useCar5;
	
	[Header("CAR 6")]
	[SerializeField] GameObject car6Canvas;
	[SerializeField] int car6amount;
	[SerializeField] Button Buycar6Button;
	[SerializeField] Button useCar6;
	
	[Header("ELEMENTS ")]
	[SerializeField] TMP_Text diamondText;
	[SerializeField] GameObject selectedText;
	[SerializeField] GameObject lowdiamonText;
	[SerializeField] Sprite offBuyButton;
	
	int diamonds;
	int diamondsCounts;
    // Start is called before the first frame update
    void Start()
    {
    	
    	diamondsCounts = PlayerPrefs.GetInt("diamondCount");
    	diamondText.text = diamondsCounts.ToString();
    	
    	car1Canvas.SetActive(true);
    	

    	
    	if(PlayerPrefs.GetInt("car2sold") != 1) // hasnt bought car2 yet
    	{
    		Buycar2Button.interactable = true;
    		useCar2.interactable = false;
    	}
    	
    	else
    	{
    		Buycar2Button.GetComponent<Image>().sprite  = offBuyButton;
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
    		Buycar3Button.GetComponent<Image>().sprite  = offBuyButton;
    		Buycar3Button.interactable = false;
    		useCar3.interactable = true;
    	}
    	
    	//**************** car 4 ********************************
    	 if(PlayerPrefs.GetInt("car4sold") != 1) // hasnt bought car3 yet
    	{
    		Buycar4Button.interactable = true;
    		useCar4.interactable = false;
    	}
    	
    	else
    	{
    		Buycar4Button.GetComponent<Image>().sprite  = offBuyButton;
    		Buycar4Button.interactable = false;
    		useCar4.interactable = true;
    	}
    	
     	//**************** car 5 ********************************
    	 if(PlayerPrefs.GetInt("car5sold") != 1) // hasnt bought car3 yet
    	{
    		Buycar5Button.interactable = true;
    		useCar5.interactable = false;
    	}
    	
    	else
    	{
    		Buycar5Button.GetComponent<Image>().sprite  = offBuyButton;
    		Buycar5Button.interactable = false;
    		useCar5.interactable = true;
    	}


    	//**************** car 6 ********************************
    	 if(PlayerPrefs.GetInt("car6sold") != 1) // hasnt bought car3 yet
    	{
    		Buycar6Button.interactable = true;
    		useCar6.interactable = false;
    	}
    	
    	else
    	{
    		Buycar6Button.GetComponent<Image>().sprite  = offBuyButton;
    		Buycar6Button.interactable = false;
    		useCar6.interactable = true;
    	}    	
    }

    // Update is called once per frame
    void Update()
    {
        diamondsCounts = PlayerPrefs.GetInt("diamondCount");
    	diamondText.text = diamondsCounts.ToString();
    }
    
    //***********************************************
    public void BackToGame()
    {
    	SceneManager.LoadScene("Game");
    }
    
    void ShowSelectedText()
    {
    	selectedText.SetActive(true);
    	Invoke("HideselectedText" , 0.6f);
    }
    
    void HideselectedText()
    {
    	selectedText.SetActive(false);
    }
    
    
    void ShowDiamondText()
    {
    	lowdiamonText.SetActive(true);
    	Invoke("HideDiamondText" , 0.6f);
    }
    
    void HideDiamondText()
    {
    	lowdiamonText.SetActive(false);
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
    	ShowSelectedText();
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
    		Buycar2Button.GetComponent<Image>().sprite  = offBuyButton;
    		PlayerPrefs.SetInt("car2sold" , 1);
    		diamonds = PlayerPrefs.GetInt("diamondCount") - car2amount;
    		PlayerPrefs.SetInt("diamondCount" , diamonds);
    		
    	}
    	
    	else
    	{
    		ShowDiamondText();
    	}
    }
    
    public void SelectCar2()
    {
    	PlayerPrefs.SetInt("selectedCar" , 2);
    	Debug.Log("selected car : " + PlayerPrefs.GetInt("selectedCar"));
    	ShowSelectedText();
    	//SceneManager.LoadScene("Intro");
    }
    
    
    
    //************** car 3 atribuites *****************
    public void Car3Next()
    {
    	car3Canvas.SetActive(false);
    	car4Canvas.SetActive(true);
    }

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
    		Buycar3Button.GetComponent<Image>().sprite  = offBuyButton;
    		PlayerPrefs.SetInt("car3sold" , 1);
    		diamonds = PlayerPrefs.GetInt("diamondCount") - car3amount;
    		PlayerPrefs.SetInt("diamondCount" , diamonds);
    		
    	}
    	
    	else
    	{
    		ShowDiamondText();
    	}
    }
    
    public void SelectCar3()
    {
    	PlayerPrefs.SetInt("selectedCar" , 3);
    	Debug.Log("selected car : " + PlayerPrefs.GetInt("selectedCar"));
    	ShowSelectedText();
    	
    	//SceneManager.LoadScene("Intro");
    }
    
    
    
    
//************** car 4 atribuites *****************

public void Car4Next()
    {
    	car4Canvas.SetActive(false);
    	car5Canvas.SetActive(true);
    }
	public void car4Back()
	{
		car3Canvas.SetActive(true);
		car4Canvas.SetActive(false);
	}
    
    public void Buycar4()
    {
    	//Debug.Log("high score : " + PlayerPrefs.GetInt("diamondCount"));
    	
    	if(car4amount  <= PlayerPrefs.GetInt("diamondCount"))
    	{
    		useCar4.interactable = true;
    		Buycar4Button.interactable = false;
    		Buycar4Button.GetComponent<Image>().sprite  = offBuyButton;
    		PlayerPrefs.SetInt("car4sold" , 1);
    		diamonds = PlayerPrefs.GetInt("diamondCount") - car4amount;
    		PlayerPrefs.SetInt("diamondCount" , diamonds);
    		
    	}
    	
    	else
    	{
    		ShowDiamondText();
    	}
    }
    
    public void SelectCar4()
    {
    	PlayerPrefs.SetInt("selectedCar" , 4);
    	Debug.Log("selected car : " + PlayerPrefs.GetInt("selectedCar"));
    	ShowSelectedText();
    	
    	//SceneManager.LoadScene("Intro");
    }
    
    
    
    
    //************** car 5 atribuites *****************

public void Car5Next()
    {
    	car5Canvas.SetActive(false);
    	car6Canvas.SetActive(true);
    }
	public void car5Back()
	{
		car4Canvas.SetActive(true);
		car5Canvas.SetActive(false);
	}
    
    public void Buycar5()
    {
    	//Debug.Log("high score : " + PlayerPrefs.GetInt("diamondCount"));
    	
    	if(car5amount  <= PlayerPrefs.GetInt("diamondCount"))
    	{
    		useCar5.interactable = true;
    		Buycar5Button.interactable = false;
    		Buycar5Button.GetComponent<Image>().sprite  = offBuyButton;
    		PlayerPrefs.SetInt("car5sold" , 1);
    		diamonds = PlayerPrefs.GetInt("diamondCount") - car4amount;
    		PlayerPrefs.SetInt("diamondCount" , diamonds);
    		
    	}
    	
    	else
    	{
    		ShowDiamondText();
    	}
    }
    
    public void SelectCar5()
    {
    	PlayerPrefs.SetInt("selectedCar" , 5);
    	Debug.Log("selected car : " + PlayerPrefs.GetInt("selectedCar"));
    	ShowSelectedText();
    	
    	//SceneManager.LoadScene("Intro");
    }
    
    
    
    //************** car 6 atribuites *****************

	public void car6Back()
	{
		car5Canvas.SetActive(true);
		car6Canvas.SetActive(false);
	}
    
    public void Buycar6()
    {
    	//Debug.Log("high score : " + PlayerPrefs.GetInt("diamondCount"));
    	
    	if(car6amount  <= PlayerPrefs.GetInt("diamondCount"))
    	{
    		useCar6.interactable = true;
    		Buycar6Button.interactable = false;
    		Buycar6Button.GetComponent<Image>().sprite  = offBuyButton;
    		PlayerPrefs.SetInt("car6sold" , 1);
    		diamonds = PlayerPrefs.GetInt("diamondCount") - car4amount;
    		PlayerPrefs.SetInt("diamondCount" , diamonds);
    		
    	}
    	
    	else
    	{
    		ShowDiamondText();
    	}
    }
    
    public void SelectCar6()
    {
    	PlayerPrefs.SetInt("selectedCar" , 6);
    	Debug.Log("selected car : " + PlayerPrefs.GetInt("selectedCar"));
    	ShowSelectedText();
    	
    	//SceneManager.LoadScene("Intro");
    }
}
