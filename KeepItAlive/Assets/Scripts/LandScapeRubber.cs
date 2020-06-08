using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LandScapeRubber : RubberMovingObject
{
    SpriteShapeController shape;
    int pointsCount;
    void Awake()
    {
        shape = GetComponent<SpriteShapeController>();
        pointsCount = shape.spline.GetPointCount();
    }

    public override void ScrollRubber(float deltaPos)
    {
        Vector2 newPos;
        Spline spline = shape.spline;
        float camWidth = GameManager.instance.CameraWidth * 2f;
        int pointIndexToMove = -1;
        for (int i = 1; i < pointsCount - 1; i++)
        {
            newPos = spline.GetPosition(i);
            newPos.x += deltaPos * bandScrollKoefficient;
            if (newPos.x > camWidth)
            {
                newPos.x -= camWidth * 2f;
                pointIndexToMove = i;
            }
            else if (newPos.x < -camWidth)
            {
                newPos.x += camWidth * 2f;
                pointIndexToMove = i;
            }
            spline.SetPosition(i, newPos);
        }

        if(pointIndexToMove >= 0)
        {
            Vector3 pos = spline.GetPosition(pointIndexToMove);
            Vector3 lt = spline.GetLeftTangent(pointIndexToMove);
            Vector3 rt = spline.GetRightTangent(pointIndexToMove);
            ShapeTangentMode tm = spline.GetTangentMode(pointIndexToMove);
            spline.RemovePointAt(pointIndexToMove);
            int insertIndex = deltaPos > 0 ? 1 : pointsCount - 2;
            spline.InsertPointAt(insertIndex, pos);
            spline.SetTangentMode(insertIndex, tm);
            spline.SetLeftTangent(insertIndex, lt);
            spline.SetRightTangent(insertIndex, rt);
        }
    }
}
