using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorController : ColorController
{
    SpriteRenderer rendr;

    public override Color GetColor()
    {
        return rendr.color;
    }

    public override void SetColor(Color color)
    {
        rendr.color = color;
    }

    protected override void Awake()
    {
        rendr = GetComponent<SpriteRenderer>();
        base.Awake();
    }
    
}
