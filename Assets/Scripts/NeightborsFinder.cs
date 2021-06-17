using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeightborsFinder : MonoBehaviour
{
    static List<BattleHex> allNeighbors = new List<BattleHex>();
    private FieldManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        GetAdjacentHice(GetComponentInParent<BattleHex>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void GetAdjacentHice(BattleHex startingHex)
    {

        int initialX = startingHex.horizontalCoordinate - 1;
        int initialY = startingHex.verticalCoordinate - 1;


        //add neighboring hice
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                //ignore middle and corners and inactive hice
                if (i != j && FieldManager.allHiceArray[initialX + i, initialY + j].battleHexState == HexState.active)
                {
                    allNeighbors.Add(FieldManager.allHiceArray[initialX + i, initialY + j]);
                    FieldManager.allHiceArray[initialX + i, initialY + j].MakeHexAvailable();
                }
            }
        }
    }
}
