using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            CollideObstacle();
        }
    }

    private void CollideObstacle()
    {
        transform.DOMove(-transform.forward * 5, .5f)
         .SetRelative()
         .SetEase(Ease.OutCubic);
    }
}
