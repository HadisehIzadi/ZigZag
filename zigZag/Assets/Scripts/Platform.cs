using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[Header("Elements")]
	public GameObject diamond;
	public bool isStartPlatform = false;
	
    // Start is called before the first frame update
    void Start()
    {
        int randomDiamond = Random.Range(0,8);
        Vector3 diamondPos = transform.position;
        diamondPos.y += 1f;
        

        
        if(randomDiamond < 1 )
        {
        	if(!isStartPlatform)
        	Instantiate(diamond , diamondPos , Quaternion.Euler(90 , 0 , 0));
        }
        	
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Fall()
    {
    	GetComponent<Rigidbody>().isKinematic = false;
    	Destroy(gameObject , 1f);
    }
    
    void OnCollisionExit(Collision collision)
    {
    	if(collision.gameObject.tag == "Player")
    	{
    		Invoke("Fall" , 0.2f);
    	}
    }
}
