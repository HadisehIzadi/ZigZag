using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{
	[SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image soundsButtonImage;
    [SerializeField] private Image HapticButtonImage;
    
    [SerializeField] private AudioSource IntroAudios;
    
    [Header(" Settings ")]
    private bool soundsState = true;
    private bool HapticState = true;
   
    
    private void Awake()
    {
        soundsState = PlayerPrefs.GetInt("sounds", 1) == 1;
        HapticState = PlayerPrefs.GetInt("Vibrate", 1) == 1;
       
    }
    	
    void Start()
    {
    	
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup()
    {
        if (soundsState)
            EnableSounds();
        else
            DisableSounds();
        
        if (HapticState)
            EnableHaptic();
        else
            DisableHaptic();


    }
    
    
    public void ChangeSoundsState()
    {
        if (soundsState)
            DisableSounds();
        else
            EnableSounds();

        soundsState = !soundsState;

        // Save the value of the sounds State
  

        //PlayerPrefs.SetInt("sounds", soundsState ? 1 : 0);
    }
    
    public void DisableSounds()
    {
    	
        soundsButtonImage.sprite = optionsOffSprite;
        AudioListener.volume = 0f;
    	PlayerPrefs.SetInt("sounds", 0);
    	//IntroAudios.volume = 0;


    }

    public void EnableSounds()
    {

        soundsButtonImage.sprite = optionsOnSprite;
        AudioListener.volume = 1f;
    	PlayerPrefs.SetInt("sounds", 1);
    	//IntroAudios.volume = 1;

    }
    
    
 // **************************************************
    
    
   public void ChangeHapticState()
    {
        if (HapticState)
            DisableHaptic();
        else
            EnableHaptic();

        HapticState = !HapticState;


    }
    
    public void DisableHaptic()
    {
    	
        HapticButtonImage.sprite = optionsOffSprite;
    	PlayerPrefs.SetInt("Vibrate", 0);


    }

    public void EnableHaptic()
    {

        HapticButtonImage.sprite = optionsOnSprite;
    	PlayerPrefs.SetInt("Vibrate", 1);


    }
}
