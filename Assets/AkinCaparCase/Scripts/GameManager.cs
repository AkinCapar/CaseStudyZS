using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float stackedAmount;
    public float maxStackAmount;
    public int collectedCoinAmount; // collected coin amount each level, so will be set 0 on each level start
    public int wallet;
    public int stackUpgradeCost;
    public bool startGame = false;
    public bool gameEnded = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void StackUpgrade()
    {
        stackedAmount++;
        wallet -= stackUpgradeCost;
        stackUpgradeCost = stackUpgradeCost * 2;
    }

}
