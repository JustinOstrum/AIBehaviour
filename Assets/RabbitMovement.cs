using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMovement : Movement
{
    float rabbitMin = 0.5f, rabbitMax = 1f;

    protected override Vector3 CalculateMovement(MovementDirection moveDir, float min, float max)
    {   
        return base.CalculateMovement(moveDir, rabbitMin, rabbitMax);
    }
}