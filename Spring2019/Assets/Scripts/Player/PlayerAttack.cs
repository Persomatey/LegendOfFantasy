﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Animator anim;
    private Coroutine myCo;
    private bool isAttacking;
    //public Component swordScript;
    public GameObject sword;
    public AudioSource swing;
    public AudioSource grassySteps; 

	void Start ()
    {
        myCo = null;
        //sword = GameObject.Find("Sword01Free");
        //sword.GetComponent<SwordDamage>().enabled = false;
	}
	

	void Update ()
    {
		if (Input.GetKeyDown("m") && !isAttacking)
        {
            // Debug.Log("Attacked");
            StartCoroutine(Attack()); 
        }
	}

    IEnumerator Attack()
    {
        swing.Play();
        grassySteps.Stop(); 
        GetComponent<CoreMovement>().enabled = false;
        sword.SetActive(true);
        //sword.GetComponent<SwordDamage>().enabled = true;
        isAttacking = true; 
        anim.Play("Attack02");
        yield return new WaitForSeconds(.4f);
        GetComponent<CoreMovement>().enabled = true;
        //sword.GetComponent<SwordDamage>().enabled = false;
        sword.GetComponent<SwordDamage>().CleanList(); 
        sword.SetActive(false);
        myCo = null;
        isAttacking = false;
    }
}
