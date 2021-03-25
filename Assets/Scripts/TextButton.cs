using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextButton : MonoBehaviour
{
    public Animator animator;
    public float showtime = 3f;

    public void ShowThreeSecText()
    {
        StartCoroutine(ShowThreeSecCoroutine());
    }

    private IEnumerator ShowThreeSecCoroutine()
    {
        animator.Play("ThreeSecTextAnimShow");
        yield return new WaitForSeconds(showtime);
        animator.Play("ThreeSecTextAnimHide");
    }


}
