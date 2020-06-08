using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsBand : RubberMovingObject
{
    [SerializeField]
    Transform[] objectsOnBand;

    private void Awake()
    {
        objectsOnBand = new Transform[transform.childCount];
        for (int i =0; i < transform.childCount; i++)
        {
            objectsOnBand[i] = transform.GetChild(i);
        }
    }

    public override void ScrollRubber(float deltaPos)
    {
        Vector2 newPos;
        float camWidth = GameManager.instance.CameraWidth * 1.5f;
        foreach(var obj in objectsOnBand)
        {
            newPos = obj.position;
            newPos.x += deltaPos * bandScrollKoefficient;
            if(newPos.x > camWidth)
            {
                newPos.x -= camWidth * 2f;
            }
            else if(newPos.x < -camWidth)
            {
                newPos.x += camWidth * 2f;
            }
            obj.position = newPos;
        }
    }
}
