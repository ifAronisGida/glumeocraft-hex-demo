
using UnityEngine;
using UnityEngine.UI;

public class TransperencyCounter : MonoBehaviour
{
    [Range(0f, 1f)] //displays the slider ranging from 0 to 1
    public float AlphaValue = 1f; // defines the current alpha (transparency)
    private Image CountryImage; //To access to the Image Component

    void Start()
    {
        CountryImage = GetComponent<Image>();//assigninig the image component to the variable
        CountryImage.alphaHitTestMinimumThreshold = AlphaValue; //specifies the minimum alpha a pixel must have 
        //to be able to respond to click

    }
    public void TaskOnClick()//prints the message to the Console 
    {
        print("Ouch!!!");
    }
}
