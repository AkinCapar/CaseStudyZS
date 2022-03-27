using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    GameManager gameManager;

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
        gameManager = GameManager.instance;
    }

    public void ActivateLevelEndUI()
    {
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNo + 1);
    }

}
