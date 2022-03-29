using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    SceneManager sceneManager;
    public float stackedAmount;
    public float maxStackAmount;
    public int collectedCoinAmount; // collected coin amount each level, so will be set 0 on each level start
    public int wallet;
    public int stackUpgradeCost;
    public bool startGame = false;
    public bool gameEnded = false;
    [SerializeField] private GameObject levelEndCamera;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        sceneManager = SceneManager.instance;
        wallet = PlayerPrefs.GetInt("savedWallet", 0);
        stackUpgradeCost = PlayerPrefs.GetInt("savedStackUpgradeCost", 10);
        stackedAmount = PlayerPrefs.GetFloat("startStackAmount", 0);
    }

    public void StackUpgrade()
    {
        if (stackUpgradeCost <= wallet)
        {
            stackedAmount++;
            wallet -= stackUpgradeCost;
            stackUpgradeCost = stackUpgradeCost * 2;
            PlayerPrefs.SetInt("savedWallet", wallet);
            PlayerPrefs.SetInt("savedStackUpgradeCost", stackUpgradeCost);
            PlayerPrefs.SetFloat("startStackAmount", stackedAmount);
        }
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        wallet = PlayerPrefs.GetInt("savedWallet", 0);
        stackUpgradeCost = PlayerPrefs.GetInt("savedStackUpgradeCost", 10);
        stackedAmount = 0;
        sceneManager.LoadFirstLevel();
    }

    public void SwitchToLevelEndCam()
    {
        levelEndCamera.gameObject.SetActive(true);
    }

}
