using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] AudioPlayer openSound;
    public bool open;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Close()
    {
        if (!open) return;
        animator.SetTrigger("Close");
        open = false;
    }

    public void Open()
    {
        if (open) return;
        animator.SetTrigger("Open");
        open = true;
        openSound.PlaySound();
    }
}
