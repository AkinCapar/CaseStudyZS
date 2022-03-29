using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private int losingStackAmount;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        Rotating();
    }

    private void Rotating()
    {
        transform.DORotate(new Vector3(0, 0, -200), 1)
                 .SetEase(Ease.Linear)
                 .SetLoops(-1, LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (gameManager.stackedAmount > 0)
            {
                gameManager.stackedAmount -= losingStackAmount;
            }
        }
    }
}
