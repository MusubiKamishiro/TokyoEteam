using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fadeをするプログラム
public class Fader : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            FadeIn();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            FadeOut();
        }
    }


    public void FadeIn()
    {
        animator.Play("fade");
    }

    public void FadeOut()
    {
        animator.Play("fadeOut");
    }
}
