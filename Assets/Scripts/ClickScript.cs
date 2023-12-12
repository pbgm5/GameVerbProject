using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public TextMeshProUGUI clickText;
    public TextMeshProUGUI clickTextTemp;
    private int clickCount = 0;
    private int temperature = 90;
    private float temperatureFloat;
    public float tempDropIncrement = 0.2f;
    public float timeUntilTempIncrease = 1;
    public float delay = 0.1f;
    private int delay2 = 3;
    private float timeElapsedTemp;
    private float timeElapsed;
    public Color orangecolor;
    private bool justClicked;

    public Transform armPivot1;
    public Transform armPivot2;

    public Transform lefteyebutton;
    public Transform righteyebutton;
    public Transform nose;
    public Transform leftbtmouth;
    public Transform rightbtmouth;

    public ParticleSystem ps;
   
    //make pivot points by making gameobject then moving it to the pivot point (make sure its on pivot mode) then move the object to child the gameobject
    //rotate parts as melting snowman 
    //particle system
    //add free sky box

    /* ideas: After a certain amount of clicks the gun breaks so the user must keep pressing a "fix button" then the gun will work again after a certain amount of clicks to the fix button 
    */
    void Start()
    {
        temperatureFloat = temperature;
        timeElapsedTemp = delay;
        
    }

    // Update is called once per frame
    void Update()
    {
        clickText.text = "Clicks: " + clickCount; // Updates the number of clicks on screen
        clickTextTemp.text = "Temperature: " + temperature+ "F"; // Updates the temperature on screen
        timeElapsed += Time.deltaTime; //amount of time passes when the game starts

        TempColor();
        //TemperatureChangeDelay();
        TemperatureIncrease();
        ClickDelay();
        float angle = Util.RemapRange(temperatureFloat, 100, 50, -90, -30);
        float eyepos = Util.RemapRange(temperatureFloat, 100, 50, 3, 4); //should be 3.5 and 3.7 not 3 and 4
        float nosepos = Util.RemapRange(temperatureFloat, 100, 50, -90, -30);  //3.589 to 3.482
        float btmouthpos = Util.RemapRange(temperatureFloat, 100, 50, -90, -30); //3.468 to 3.403
        if (Input.GetMouseButtonDown(0)) // Press  the left mouse button anywhere on the screen and the click counter will go up
        {
            Click();
            temperatureFloat -= tempDropIncrement;
            temperature = (int)temperatureFloat;
            timeElapsedTemp = 0;
            
            //temperature--;
        }
        armPivot1.localEulerAngles = new Vector3(angle, armPivot1.localEulerAngles.y, armPivot1.localEulerAngles.z);
        armPivot2.localEulerAngles = new Vector3(angle, armPivot2.localEulerAngles.y, armPivot2.localEulerAngles.z);
        //armPivot.localRotation = Quaternion.Euler(armRot);
        lefteyebutton.localPosition = new Vector3(lefteyebutton.localPosition.x, eyepos, lefteyebutton.localPosition.z);
        righteyebutton.localPosition = new Vector3(righteyebutton.localPosition.x, eyepos, righteyebutton.localPosition.z);
        nose.localPosition = new Vector3(nose.localPosition.x, nosepos, nose.localPosition.z);
        leftbtmouth.localPosition = new Vector3(leftbtmouth.localPosition.x, btmouthpos, leftbtmouth.localPosition.z);
        rightbtmouth.localPosition = new Vector3(rightbtmouth.localPosition.x, btmouthpos, rightbtmouth.localPosition.z);

        /*How to make timer
        
        public float timeelapsed = 0 //public to make it changeable in the inspector
        public float duration = 3; //the limit of the time 

        if (timeelapsed < duration) {
        timeelapsed+= time.deltatime;
        //code
        } else {
        //code
        timeelapsed = 0;
         */
    }

    public void TemperatureIncrease()
    {
        if (timeElapsed >= timeUntilTempIncrease && !justClicked)
        {
            temperature++;
            timeElapsed = 0;
        }
    }
    public void TemperatureChangeDelay()
    {
        if (timeElapsedTemp < delay2)
        {
            timeElapsedTemp += Time.deltaTime;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            temperature--;
            timeElapsedTemp = 0;
        }
    }
    public void ClickDelay()
    {
        if (timeElapsedTemp < delay)
        {
            timeElapsedTemp += Time.deltaTime;
            justClicked = true;
        }
        else  
        {
            justClicked = false;
            //timeElapsedTemp = 0;
        }
    }

    public void Click()
    {
        clickCount++;
        ps.Emit(15);

    }

    public void TempColor() // Temperture Counter changes color depending on how many degrees it is 
    {
        if (temperature <= 60)
        {
            clickTextTemp.color = Color.blue;
        }
        else if (temperature >= 61 && temperature < 81)
        {
           clickTextTemp.color = orangecolor; 
        }
        else
        {
            clickTextTemp.color = Color.red;
        }
    
    }
}