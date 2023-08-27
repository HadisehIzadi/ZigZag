using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
