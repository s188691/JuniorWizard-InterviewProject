using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public Animator animator;

    public void ShowPopUp()
    {
        animator.Play("PopUpAnimShow");
    }

    public void HidePopUp()
    {
        animator.Play("PopUpAnimHide");
    }
}
