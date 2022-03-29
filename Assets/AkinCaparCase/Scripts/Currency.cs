using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Currency : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private int currencyValue;
    [SerializeField] private Transform playersPosition;
    [SerializeField] private float moveTowardsSpeed;
    private bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        IdleAnimation();
    }

    private void IdleAnimation()
    {
        transform.DORotate(new Vector3(0, 200, 0), 1)
         .SetEase(Ease.Linear)
         .SetLoops(-1, LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, playersPosition.position, moveTowardsSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetCollected();
            isCollected = true;
        }
    }

    private void GetCollected()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameManager.wallet += currencyValue;
        PlayerPrefs.SetInt("savedWallet", gameManager.wallet);
        gameManager.collectedCoinAmount += currencyValue;
        var sequence = DOTween.Sequence();

        sequence.Append(
            transform.DOMove(Vector3.up * 3, .25f)
                     .SetRelative()
                     .SetEase(Ease.InOutSine)
            );
        transform.DOScale(0, 2);
    }
}
