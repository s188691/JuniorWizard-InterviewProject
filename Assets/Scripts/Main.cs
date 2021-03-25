﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Main : MonoBehaviour
{
    
    public SoundsClass spellOne;
    public SoundsClass spellTwo;
    public SoundsClass spellThree;
    public SoundsClass[] spellsArray = new SoundsClass[3];
    public SoundsClass[] spellsFiltered;
    public int randomSpell;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        spellOne.name = "SpellOne";
        spellOne.playable = true;

        spellTwo.name = "SpellTwo";
        spellTwo.playable = true;

        spellThree.name = "SpellThree";
        spellThree.playable = true;
        
        spellsArray[0] = spellOne;
        spellsArray[1] = spellTwo;
        spellsArray[2] = spellThree;
        
    }

    // Update is called once per frame
    void Update()
    {

        spellsFiltered = spellsArray.Where(s => s.playable).ToArray();

        try
        {
        randomSpell = Random.Range(0, spellsFiltered.Length);
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("All spells are off");
        }
        
    }
    
    AudioClip RandomClip()
    {
    return spellsFiltered[randomSpell].spellSFX;
    }

    public void SpellButton()
    {
        try
        {
        audioSource.PlayOneShot(RandomClip());
        } 
        catch (System.IndexOutOfRangeException)
        {
        Debug.Log("All spells are off");
        }
    }

    public void SpellOneToggle(bool toggleBool)
    {
        spellOne.playable = toggleBool;
    }

    public void SpellTwoToggle(bool toggleBool)
    {
        spellTwo.playable = toggleBool;
    }

    public void SpellThreeToggle(bool toggleBool)
    {
        spellThree.playable = toggleBool;
    }


}