using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	[Header("Elements")]
    public int speed = 10;
    bool movingLeft = true;
    bool firstInput = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (GameManager.instance.gameStarted) {
			Move();
			CheckInput();
		}
    	
    	if(transform.position.y <= -2f){
    		GameManager.instance.GameOver();
    		Destroy(gameObject);
    	}
    }
    
    
    void Move()
    {
    	transform.position += transform.forward * speed * Time.deltaTime;
    }
    
    void CheckInput()
    {
    	if(firstInput)
    	{
    		firstInput = false;
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
}
