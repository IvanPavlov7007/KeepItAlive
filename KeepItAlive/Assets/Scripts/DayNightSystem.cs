using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour
{

    [Range(0f, 1f), SerializeField]
    float illuminationVal;

    [SerializeField]
    ColorController[] colorControlledObjects;

    [SerializeField]
    Transform moon, sun;

    [SerializeField]
    float currentTime = 1f; // High Noon, whereas 0 is High Moon
    [SerializeField]
    float timeVelocity, dawnAngle;

    float celestialRotationPointDist;
    Vector3 dawnPos, sunsetPos;

    private void Awake()
    {
        colorControlledObjects = FindObjectsOfType<ColorController>();
        celestialRotationPointDist = sun.localPosition.magnitude;
        dawnPos = Quaternion.Euler(0, 0, 90f - dawnAngle) * new Vector2(1f, 0f) * celestialRotationPointDist;
        sunsetPos = Quaternion.Euler(0, 0, 90f + dawnAngle) * new Vector2(1f, 0f) * celestialRotationPointDist;
    }

    void Update()
    {
        currentTime = (currentTime + Time.deltaTime * timeVelocity) % 2f;

        if(currentTime >= 0.6f && currentTime < 1.4f)
        {
            LerpCelestialPos(sun, (currentTime - 0.6f) * 1.25f);
        }
        else if (currentTime < 0.4f || currentTime >= 1.6f)
        {
            LerpCelestialPos(moon, (currentTime > 1f? currentTime - 1.6f : currentTime + 0.4f) * 1.25f);
        }
        else if(currentTime >= 0.4f && currentTime < 0.6f)
        {
            LerpIllumination(1f - (currentTime - 0.4f) * 5f);
        }
        else
        {
            LerpIllumination((currentTime - 1.4f) * 5f);
        }

        
    }

    void LerpIllumination(float val)
    {
        foreach (var col in colorControlledObjects)
        {
            col.SetLerpValue(val);
        }
    }
    void LerpCelestialPos(Transform celestial, float val)
    {
        celestial.localPosition = Vector3.Slerp(dawnPos, sunsetPos, val);
    }
}
