using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Animator anim;
    SpriteRenderer rendr;

    bool flipped = false, allowedToMove = false;

    [SerializeField]
    float maxWalkVelocity;

    int walkDirIndex = Animator.StringToHash("WalkDir");

    void Awake()
    {
        anim = GetComponent<Animator>();
        rendr = GetComponent<SpriteRenderer>();
    }

    

    public void OnMove(int dir)
    {
        anim.SetInteger(walkDirIndex, dir);
        if ((flipped && dir > 0) || (!flipped && dir < 0))
        {
            flipped = !flipped;
            rendr.flipX = flipped;
        }
    }

    public void AllowToMove()
    {
        allowedToMove = true;
    }

    public void StopMove()
    {
        allowedToMove = false;
    }
}
