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
            gameManager.wallet += currencyValue;
            GetCollected();
            isCollected = true;
        }
    }

    private void GetCollected()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        var sequence = DOTween.Sequence();

        sequence.Append(
            transform.DOMove(Vector3.up * 3, .25f)
                     .SetRelative()
                     .SetEase(Ease.InOutSine)
            );
        transform.DOScale(0, 2);
    }
}