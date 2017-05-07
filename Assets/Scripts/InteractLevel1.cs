﻿using UnityEngine;
using UnityEngine.UI;

public class InteractLevel1 : Interact
{
    public GameObject monster;
    public GameObject thorn;
    public Text dialog;

    private Animator eyeAnimator;
    private Animator mouthAnimator;

    void Start()
    {
        eyeAnimator = monster.transform.FindChild("Eyes").GetComponent<Animator>();
        mouthAnimator = monster.transform.FindChild("Mouth").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Cast().transform != null)
            {
                if (Cast().transform.name == "Mouth")
                {
                    eyeAnimator.SetBool("isActive", true);
                    mouthAnimator.SetBool("isActive", true);
                    thorn.SetActive(true);
                }

                if (Cast().transform.name == "Thorn")
                {
                    if (Cast().transform.gameObject.GetComponent<Rigidbody2D>() == null)
                    {
                        Cast().transform.gameObject.AddComponent<Rigidbody2D>();
                    }
                }
            }
        }

        if (thorn == null|| Mathf.Abs(thorn.transform.position.x) > 3)
        {
            eyeAnimator.SetBool("isActive", true);
            mouthAnimator.SetBool("isActive", true);
            eyeAnimator.SetBool("isHappy", true);
            mouthAnimator.SetBool("isHappy", true);
            dialog.text = "Yey!";
        }
    }
}
