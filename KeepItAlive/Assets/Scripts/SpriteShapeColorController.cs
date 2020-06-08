using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteShapeColorController : ColorController
{
    SpriteShapeRenderer shapeRndr;
    protected override void Awake()
    {
        shapeRndr = GetComponent<SpriteShapeRenderer>();
        base.Awake();
    }

    public override Color GetColor()
    {
        return shapeRndr.color;
    }

    public override void SetColor(Color color)
    {
        shapeRndr.color = color;
    }
}
