using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackColorController : ColorController
{
    Camera cam;

    protected override void Awake()
    {
        cam = GetComponent<Camera>();
        base.Awake();
    }
    public override Color GetColor()
    {
        return cam.backgroundColor;
    }

    public override void SetColor(Color color)
    {
        cam.backgroundColor = color;
    }
}
