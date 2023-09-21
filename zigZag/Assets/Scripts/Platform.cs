using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[Header("Elements")]
	[SerializeField] GameObject diamond;
	[SerializeField] GameObject bigScaler;
	[SerializeField] GameObject litScaler;
	[SerializeField] bool isStartPlatform = false;
	bool isDiamond = false;
	bool isBigScaler = false;
	
    // Start is called before the first frame update
    void Start()
    {
        int randomDiamond = Random.Range(0,8);
        int randomBigScaler = Random.Range(0,15);
        int randomLitScaler = Random.Range(0,15);
        
        Vector3 diamondPos = transform.position;
        diamondPos.y += 1f;
        

        
        if(randomDiamond < 1 )
        {
        	if(!isStartPlatform)
        	Instantiate(diamond , diamondPos , Quaternion.Euler(90 , 0 , 0));
        	isDiamond = true;
        }
        
        if(randomBigScaler < 1  && isDiamond == false)
        {
        	if(!isStartPlatform)
        	Instantiate(bigScaler , diamondPos , Quaternion.Euler(90 , 0 , 0));
        }
        
        if(randomLitScaler < 1  && isDiamond == false && isBigScaler == false)
        {
        	if(!isStartPlatform)
        	Instantiate(litScaler , diamondPos , Quaternion.Euler(90 , 0 , 0));
        }
        	
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Fall()
	{
		GetComponent<Rigidbody>().isKinematic = false;
		for (var i = this.transform.childCount - 1; i >= 0; i--) {
			Object.Destroy(this.transform.GetChild(i).gameObject);
		}
		Destroy(gameObject, 1f);
	}
    
    void OnCollisionExit(Collision collision)
    {
    	if(collision.gameObject.tag == "Player")
    	{
    		Invoke("Fall" , 0.2f);
    	}
    }
}
