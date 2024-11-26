using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class handinput : MonoBehaviour
{
    public InputActionProperty animationPinch;
    public InputActionProperty animationPoigne;


    public Animator mainAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerV = animationPinch.action.ReadValue<float>();
        mainAnimator.SetFloat("Trigger", triggerV);
        float poigneV = animationPoigne.action.ReadValue<float>();
        mainAnimator.SetFloat("Grip", poigneV);
    }
}
