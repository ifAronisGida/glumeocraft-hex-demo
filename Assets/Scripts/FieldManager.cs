using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public RowManager[] allRowsArray;
    static public BattleHex[,] allHiceArray;
    static public List<BattleHex> activeHexList = new List<BattleHex>();

    // Start is called before the first frame update
    void Awake()
    {
        allRowsArray = GetComponentsInChildren<RowManager>();
        for (int i = 0; i < allRowsArray.Length; i++) {
            allRowsArray[i].allHiceInRow = allRowsArray[i].GetComponentsInChildren<BattleHex>();
            allRowsArray[i].numberOfHice = allRowsArray[i].allHiceInRow.Length;
        }
        CreateAllHiceArray();
        CreateActiveHiceList();
        CreateActiveHiceArray();
    }

   private void CreateAllHiceArray() 
   {
        int height = allRowsArray.Length;
        allHiceArray = new BattleHex[GetMaximumWidth(), height];

        for (int i = 0; i < height; i++) 
        {
            int rowWidth = allRowsArray[i].numberOfHice;
            print("current row width: " + rowWidth);
            for (int j = 0; j < rowWidth; j++) 
            {

                print("allHiceArray[" + j + ", " + i + "] = allRowsArray[" + height + "-" + i + "-1" + "].allHiceInRow[" + rowWidth + "-" + j + "-1" + "]");
                allHiceArray[j, i] = allRowsArray[height - i - 1].allHiceInRow[rowWidth - j - 1];
                print("allHiceArray[" + j + ", " + i + "].verticalCoordinate =" + i + "+1");
                allHiceArray[j, i].verticalCoordinate = i + 1;
                print("allHiceArray[" + j + ", " + i + "].horizontalCoordinate =" + j + "+1");
                allHiceArray[j, i].horizontalCoordinate = j + 1;


            }
        }
   }

    // need max length of rows because rows are not similar length
    private int GetMaximumWidth() 
    {
        int maximumNumberOfHice = 0;
        for (int i = 0; i < allRowsArray.Length; i++) 
        {
            if (allRowsArray[i].numberOfHice > maximumNumberOfHice) 
            {
                maximumNumberOfHice = allRowsArray[i].numberOfHice;
            }
        }
        print("Maximum number of Hice in a row is: " + maximumNumberOfHice);
        return maximumNumberOfHice;
    }

    // currently don't need this, we init active Hice manually
    private void CreateActiveHiceArray()
    {
        foreach (BattleHex hex in allHiceArray)
        {
            if (hex != null)
            {
                hex.SetActiveStatus();
                hex.SetTextToCoordinates();
            }

        }
    }

    private void CreateActiveHiceList()
    {
        //look for active hice in all hice
        foreach (BattleHex hex in allHiceArray)
        {
            if (hex != null)
            {
                print(hex.Landscape.color.b);

                if (hex.battleHexState == HexState.active)
                {
                    //adds active hice to list
                    activeHexList.Add(hex);
                }
            }
            
        }

        print("Active hice number: "+activeHexList.Count);
    }

}
