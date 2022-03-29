using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameManager gameManager;
    SceneManager sceneManager;
    [SerializeField] private Image stackBar;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        sceneManager = SceneManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        SetStackBar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            CollideObstacle();
        }

        if(collision.gameObject.tag == "Finish")
        {
            gameManager.gameEnded = true;
            gameManager.startGame = false;
            sceneManager.ActivateLevelEndUI();
        }
    }

    private void CollideObstacle()
    {
        transform.DOMove(-transform.forward * 5, .5f)
         .SetRelative()
         .SetEase(Ease.OutCubic);
    }

    private void SetStackBar()
    {
        stackBar.fillAmount = (gameManager.stackedAmount / gameManager.maxStackAmount);
    }
}
