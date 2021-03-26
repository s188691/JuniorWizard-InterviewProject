using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SoundButton : MonoBehaviour
{
    
    public SoundsClass spellOne;
    public SoundsClass spellTwo;
    public SoundsClass spellThree;
    public SoundsClass[] spellsArray = new SoundsClass[3];
    public SoundsClass[] spellsFiltered;
    public int randomSpell;
    public AudioSource audioSource;
    public float buttonCooldown = 2f;
    public Button spellButton;
    public Animator animator;
    
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
    
    AudioClip RandomClip()
    {
        return spellsFiltered[randomSpell].spellSFX;
    }

    public void SpellButton()
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
        
        if (spellsFiltered != null && spellsFiltered.Length != 0){
            StartCoroutine(ButtonCooldownCoroutine());
        } else {
            StartCoroutine(SpellsOffCoroutine());
        }

        try
        {
            audioSource.PlayOneShot(RandomClip());
        } 
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("All spells are off");
        }
    }

    private IEnumerator ButtonCooldownCoroutine()
    {
        spellButton.interactable = false;
        animator.Play("SpellsCdTextShow");
        yield return new WaitForSeconds(buttonCooldown);
        animator.Play("SpellsCdTextHide");
        spellButton.interactable = true;
    }

    private IEnumerator SpellsOffCoroutine()
    {
        animator.Play("SpellsOffShow");
        yield return new WaitForSeconds(1f);
        animator.Play("SpellsOffHide");
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
