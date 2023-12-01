using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int takenHitCount = 0;
    public GameManager _gameManager;
    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log("hasar sayısı : " + takenHitCount.ToString());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && _gameManager.onAttack == true)
        {
            UnityEngine.Debug.Log("vuruyor");
            takenHitCount++;
        }
        
    }
}
