using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressOpen : MonoBehaviour
{
    public Transform visualTarget;
    public Animator animator;
    public string boolName = "open";
    public string ballTag = "ball";

    private Vector3 initialLocalPos;
    public float resetSpeed = 5;
    private bool freeze = false;

    void Start()
    {
        initialLocalPos = visualTarget.localPosition;

        Collider buttonCollider = GetComponent<Collider>();
        if (buttonCollider == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
    }

    void FixedUpdate()
    {
        if (freeze)
            return;

        visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * resetSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(ballTag))
        {
            ToggleDoorOpen();
        }
    }

    public void ToggleDoorOpen()
    {
        bool isOpen = animator.GetBool(boolName);
        animator.SetBool(boolName, !isOpen);
    }
}
