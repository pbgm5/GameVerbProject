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
    private float timeElapsedTemp;
    private float timeElapsed;
    public Color orangecolor;
    private bool justClicked;
   

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
        timeElapsed += Time.deltaTime;

        TempColor();
        //TemperatureChangeDelay();
        TemperatureIncrease();
        ClickDelay();

        if (Input.GetMouseButtonDown(0)) // Press  the left mouse button anywhere on the screen and the click counter will go up
        {
            Click();
            temperatureFloat -= tempDropIncrement;
            temperature = (int)temperatureFloat;
            timeElapsedTemp = 0;
            //temperature--;
        }
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
        if (timeElapsedTemp < delay)
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