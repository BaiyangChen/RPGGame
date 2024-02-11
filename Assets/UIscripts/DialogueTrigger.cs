﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueBox;
    public GameObject player;
    public Animator anim;

    private FreeLookCam fc;
    private bool reset = false;
    public bool isDialogue = false;

    

    
    private void OnTriggerEnter(Collider other)
    {
        
        switch (transform.parent.tag)
        {
            case "NPC1":
                DialogueManager.id = 1;
                break;
            case "NPC2":
                DialogueManager.id = 2;
                break;
            case "NPC3":
                DialogueManager.id = 3;
                break;
            case "NPC4":
                DialogueManager.id = 4;
                break;
        }

        if (other.gameObject.tag == "Player" && isDialogue == false)
        {
            
            dialogueBox.SetActive(true);
            FreeLookCam.OnDialogue = true;
            GameObject.FindWithTag("Player").GetComponent<playerAttack>().CanAttack = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;               
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            isDialogue = true;

            
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        GameObject.FindWithTag("Player").GetComponent<playerAttack>().CanAttack = true;
    }

    
}
