using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LookAt : MonoBehaviour
{
	[SerializeField] GameObject[] Cars;
	private CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
    	var vcam = GetComponent<CinemachineVirtualCamera>();
    	
    	Debug.Log(" car to follow : " + PlayerPrefs.GetInt("selectedCar"));
    	//SetLookAt(Cars[PlayerPrefs.GetInt("selectedCar") - 1].transform);
    	
    	vcam.Follow = Cars[PlayerPrefs.GetInt("selectedCar") - 1].transform;
    	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetLookAt(Transform target)
    {
    	vcam.Follow = target;
    }
}
