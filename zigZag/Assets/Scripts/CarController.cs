using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	[Header("Elements")]
    [SerializeField] float speed ;
    [SerializeField] float speedGainPerSecond;
    [SerializeField] GameObject diamondVfx;
    [SerializeField] GameObject BigScalerVfx;
    [SerializeField] GameObject litScalerVfx;
    [SerializeField] GameObject tapText;
    [SerializeField] float Bigscalevalue;
    [SerializeField] AdManager adManager;
    bool movingLeft = true;
    bool firstInput = true;
    
    int diamondCount;
    Vector3 lastPos;


    
    
    // Start is called before the first frame update
    void Start()
    {
    	diamondCount = PlayerPrefs.GetInt("diamondCount" , 0);
    	
    	
    }

    // Update is called once per frame
    void Update()
    {
    	
    	
    	
		if (GameManager.instance.gameStarted) {
			Move();
			CheckInput();
		}
    	
    	if(transform.position.y <= -1f || transform.position.y >= 1.2f){
//    		lastPos = transform.position;
//    		Debug.Log("last pos = " + lastPos);
//    		gameObject.SetActive(false);

			if(PlayerPrefs.GetInt("Vibrate") == 1)
	    		Handheld.Vibrate();
			adManager.Show();
    		GameManager.instance.GameOver();
    		
    		Destroy(gameObject);
    		
    	}
    }
    
    
    void Move()
    {
    	speed += speedGainPerSecond * Time.deltaTime;
    	
    	transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    void CheckInput()
    {
    	if(firstInput)
    	{
    		firstInput = false;
    		tapText.SetActive(false);
    		return;
    	}
    	
    	if(Input.GetMouseButtonDown(0))
    		ChangeDirection();
    	
    }
    
    
    void ChangeDirection()
    {
    	if(movingLeft)
    	{
    		transform.rotation  = Quaternion.Euler(0,90,0);
    		movingLeft = false;
    	}
    	else
    	{
    		transform.rotation  = Quaternion.Euler(0,0,0);
    		movingLeft = true;
    	}
    }
    
    void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.tag == "Diamond")
    	{
    		
    		diamondCount = PlayerPrefs.GetInt("diamondCount") + 1 ;
    		PlayerPrefs.SetInt("diamondCount" , diamondCount);
    		Debug.Log("diamons : " +PlayerPrefs.GetInt("diamondCount" , 0) );
    		
    		Instantiate(diamondVfx , other.transform.position , diamondVfx.transform.rotation);
    		Destroy(other.gameObject);
    		GameManager.instance.IncreamentScore();
    	}
    	
    	
    	if(other.gameObject.tag == "BigScaler")
    	{
    		transform.localScale *= Bigscalevalue;
    		Debug.Log("scale : " + transform.localScale);
    		Instantiate(BigScalerVfx , other.transform.position , BigScalerVfx.transform.rotation);
    		GameManager.instance.playscaledSound();
    		Destroy(other.gameObject);
    	}
    	
    	if(other.gameObject.tag == "litScaler")
    	{

    		transform.localScale /= Bigscalevalue;
    		Debug.Log("scale : " + transform.localScale);
    		Instantiate(litScalerVfx , other.transform.position , litScalerVfx.transform.rotation);
    		GameManager.instance.playscaledSound();
    		Destroy(other.gameObject);
    	}
    }
}
