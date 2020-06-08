using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorController : MonoBehaviour
{
    [SerializeField]
    bool useDefaultAsDayColor = true;
    public Color nightColor, dayColor;

    protected virtual void Awake()
    {
        if (useDefaultAsDayColor)
            dayColor = GetColor();
    }

    public virtual void SetLerpValue(float val)
    {
        SetColor(Color.Lerp(dayColor, nightColor, val));
    }

    public abstract Color GetColor();
    public abstract void SetColor(Color color);
}
