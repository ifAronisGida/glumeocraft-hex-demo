using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HexState {inactive, active};

public class BattleHex : MonoBehaviour {  
    public int horizontalCoordinate;
    public int verticalCoordinate;
    public HexState battleHexState;
    public Image Landscape;
    public bool isStartingHex = false;
    public Text Pos;
    

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void SetTextToCoordinates()
    {
        Pos = GetComponentInChildren<Text>();
        if (Pos != null)
        {
            Pos.text = "v: "+ verticalCoordinate + ", " + "h: "+horizontalCoordinate;
        }
    }

    public void SetActiveStatus()
    {
        if (Landscape.color.b == 1 &&
            Landscape.color.g == 1 &&
            Landscape.color.r == 1 && 
            Landscape.color.a == 1)
        {
            battleHexState = HexState.active;
        } 
        else
        {
            battleHexState = HexState.inactive;
        }
    }

    public void MakeHexAvailable()
    {
        if (battleHexState == HexState.active)
        {
            Landscape.color = new Color32(50, 250, 50, 255);
        }
    }
}
