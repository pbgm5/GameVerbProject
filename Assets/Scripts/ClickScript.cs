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
    public float delay = 2;
    private float timeElapsedTemp;
    private float timeElapsed = Time.deltaTime;
    public Color orangecolor;

    /* ideas: After a certain amount of clicks the gun breaks so the user must keep pressing a "fix button" then the gun will work again after a certain amount of clicks to the fix button 
    */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clickText.text = "Clicks: " + clickCount; // Updates the number of clicks on screen
        clickTextTemp.text = "Temperature: " + temperature+ "F"; // Updates the temperature on screen

        TempColor();
        TemperatureChangeDelay();
        //TemperatureIncrease();


        if (Input.GetMouseButtonDown(0)) // Press  the left mouse button anywhere on the screen and the click counter will go up
        {
            Click();
            //temperature--;
        }
    }

    public void TemperatureIncrease()
    {
        if (timeElapsed >= 5)
        {
            temperature++;
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
           clickTextTemp.color = orangecolor; //change to orange
        }
        else
        {
            clickTextTemp.color = Color.red;
        }
    
    }
}