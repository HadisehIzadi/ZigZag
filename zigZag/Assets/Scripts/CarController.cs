using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	[Header("Elements")]
    public float speed ;
    public float speedGainPerSecond;
    public GameObject diamondVfx;
    [SerializeField] GameObject tapText;
    bool movingLeft = true;
    bool firstInput = true;
    
    int diamondCount;


    
    
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
    	
    	if(transform.position.y <= -1f || transform.position.y >= 0.6f){
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
    }
}
