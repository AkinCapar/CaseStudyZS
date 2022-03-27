using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI instance;

    GameManager gameManager;
    SceneManager sceneManager;


    private int currentLevelNo;
    [SerializeField] public TextMeshProUGUI startUIWallet;
    [SerializeField] public TextMeshProUGUI inGameUIWallet;
    [SerializeField] public TextMeshProUGUI levelEndUIWallet;
    [SerializeField] public TextMeshProUGUI startUILevelNo;
    [SerializeField] public TextMeshProUGUI inGameUILevelNo;
    [SerializeField] public TextMeshProUGUI levelEndUICollectedAmount;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        gameManager = GameManager.instance;
        sceneManager = SceneManager.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevelNo = sceneManager.sceneNo + 1;
    }

    // Update is called once per frame
    void Update()
    {
        startUIWallet.text = gameManager.wallet.ToString();
        inGameUIWallet.text = gameManager.wallet.ToString();
        levelEndUIWallet.text = gameManager.wallet.ToString();

        startUILevelNo.text = "Level " + currentLevelNo.ToString();
        inGameUILevelNo.text = "Level " + currentLevelNo.ToString();

        levelEndUICollectedAmount.text = gameManager.collectedCoinAmount.ToString();
    }
}
