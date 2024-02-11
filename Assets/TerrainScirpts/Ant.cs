﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ant : MonoBehaviour
{
    public Text EagleName;
    public Image EagleNameBorder;
    public GameObject arrow;
    public Transform player;

    public GameObject thirdQuest;
    public AudioSource AttackMusic;

    // Start is called before the first frame update
    void Start()
    {
        EagleName.canvasRenderer.SetAlpha(0.0f);
        EagleNameBorder.canvasRenderer.SetAlpha(0.0f);
        AttackMusic = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) <= 50f)
        {
            DialogueManager.id = 6;
            arrow.SetActive(false);
            fadeIn();
        }
        else
        {
            fadeOut();
            thirdQuest.SetActive(false);
           
        }
    }

    void fadeOut()
    {
        EagleName.CrossFadeAlpha(0, 2, false);
        EagleNameBorder.CrossFadeAlpha(0, 2, false);
    }

    void fadeIn()
    {
        EagleName.CrossFadeAlpha(1, 2, false);
        EagleNameBorder.CrossFadeAlpha(1, 2, false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AttackMusic.Play();
            GameObject.Find("Trigger the town").GetComponent<Town>().ThemeMusic.Stop();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        AttackMusic.Stop();
        GameObject.Find("Trigger the town").GetComponent<Town>().ThemeMusic.Play();
    }


}
