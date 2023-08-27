using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
	[Header("Elements")]
	public Transform lastPlatform;
	public GameObject platformPrefab;
	Vector3 lastPos;
	Vector3 newPos;
	bool stopped = false;
	
    // Start is called before the first frame update
    void Start()
    {
    	lastPos = lastPlatform.position;
    	StartCoroutine(spawnPlatform());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    void GeneratePos()
    {
    	newPos = lastPos;
    	
    	int rand = Random.Range(0,2);
    	
    	if(rand >0)
    		newPos.x += 2f;
    	else
    		newPos.z += 2f;
    }
    
    
    IEnumerator spawnPlatform()
    {
    	while(!stopped){
    	GeneratePos();
    	
    	Instantiate(platformPrefab , newPos , Quaternion.identity);
    	lastPos = newPos;
    	yield return new WaitForSeconds(0.1f);
    	}
    }
}
