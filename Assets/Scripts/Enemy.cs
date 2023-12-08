using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int takenHitCount = 0;
    public int deadHitCount = 5;
    public float speed = 5f;
    public GameManager _gameManager;
    public GameObject player;
    public Vector3 playerDistance;
    public Rigidbody2D rgb;
    public Animator e_animator;
    
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        e_animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
        Debug.Log("hasar sayısı : " + takenHitCount.ToString());
        if (takenHitCount == deadHitCount)
        {
            //Destroy(gameObject);
            //gameObject.SetActive(false);
            e_animator.SetTrigger("Death");
            Debug.Log("öldü");
            StartCoroutine(DieEnemy());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && _gameManager.onAttack == true)
        {
            UnityEngine.Debug.Log("vuruyor");
            e_animator.SetTrigger("Hurt");
            takenHitCount++;
        }
        
    }

    IEnumerator DieEnemy()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
