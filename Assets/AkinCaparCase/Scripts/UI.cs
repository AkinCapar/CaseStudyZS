using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;

    GameManager gameManager;
    SceneManager sceneManager;


    public int currentLevelNo;
    private int walletUI;
    [SerializeField] public TextMeshProUGUI startUIWallet;
    [SerializeField] public TextMeshProUGUI inGameUIWallet;
    [SerializeField] public TextMeshProUGUI levelEndUIWallet;
    [SerializeField] public TextMeshProUGUI startUILevelNo;
    [SerializeField] public TextMeshProUGUI inGameUILevelNo;
    [SerializeField] public TextMeshProUGUI levelEndUICollectedAmount;
    [SerializeField] public TextMeshProUGUI stackUpgradeCost;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        sceneManager = SceneManager.instance;
        currentLevelNo = PlayerPrefs.GetInt("levelNo", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        PlayerPrefs.SetInt("levelNo", currentLevelNo);
        if(currentLevelNo == 0)
        {
            currentLevelNo++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        startUIWallet.text = gameManager.wallet.ToString();
        inGameUIWallet.text = gameManager.wallet.ToString();
        levelEndUIWallet.text = gameManager.wallet.ToString();

        stackUpgradeCost.text = gameManager.stackUpgradeCost.ToString();

        startUILevelNo.text = "Level " + currentLevelNo.ToString();
        inGameUILevelNo.text = "Level " + currentLevelNo.ToString();

        levelEndUICollectedAmount.text = gameManager.collectedCoinAmount.ToString();
    }
}
