using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    GameManager gameManager;
    UI ui;
    public int sceneNo;
    [SerializeField] public GameObject startUI;
    [SerializeField] public GameObject inGameUI;
    [SerializeField] public GameObject levelEndUI;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        sceneNo = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        ui = UI.instance;
        gameManager = GameManager.instance;
    }

    public void ActivateLevelEndUI()
    {
        ui.currentLevelNo++;
        PlayerPrefs.SetInt("levelNo", ui.currentLevelNo);
        gameManager.SwitchToLevelEndCam();
        levelEndUI.SetActive(true);
        DeactivateInGameUI();
    }

    public void ActivateInGameUI()
    {
        gameManager.startGame = true;
        inGameUI.SetActive(true);
        DeactivateStartUI();
    }

    public void DeactivateInGameUI()
    {
        inGameUI.SetActive(false);
    }

    public void DeactivateStartUI()
    {
        startUI.SetActive(false);
    }

    public void LoadNextScene()
    {
        if(sceneNo == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNo + 1);
        }
    }

    public void LoadFirstLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
