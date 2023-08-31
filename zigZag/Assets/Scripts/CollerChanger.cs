using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollerChanger : MonoBehaviour
{
	public Color[] colors;
	
	Camera cam;
	
    // Start is called before the first frame update
    void Start()
    {
    	cam = GetComponent<Camera>();
    	
    	StartCoroutine("colorChange");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator colorChange()
    {
    	while(true)
    	{
    		int randCol = Random.Range(0 , 5);
    		cam.backgroundColor = colors[randCol];
    		
    		yield return new WaitForSeconds(10f);
    	}
    }
}
