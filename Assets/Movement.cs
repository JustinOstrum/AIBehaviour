using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public enum MovementDirection { Up, Down, Left, Right, UpRight, UpLeft, DownRight, DownLeft }

    public MovementDirection moveDirection;

    NavMeshAgent navAgent;

    float movementTimer, moveDist;
    protected float randomMin = 1f, randomMax = 4f;

    Vector3 MovementVector;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        movementTimer += Time.deltaTime;

        if(movementTimer > 5f)
        {
            movementTimer = 0;
            moveDirection = (MovementDirection)Random.Range(0,8);            
            
            GameUpdate();
        }
    }    

    public bool GameUpdate()
    {
        navAgent.destination = transform.position + CalculateMovement(moveDirection, randomMin, randomMax);
        return true;
    }

    protected virtual Vector3 CalculateMovement(MovementDirection moveDir, float min, float max)
    {
        moveDist = Random.Range(min, max);

        switch (moveDir)
        {
            case MovementDirection.Up:
                MovementVector = new Vector3(0, 0, moveDist);

                break;
            case MovementDirection.Down:
                MovementVector = new Vector3(0, 0, -moveDist);

                break;
            case MovementDirection.Left:
                MovementVector = new Vector3(-moveDist, 0, 0);

                break;
            case MovementDirection.Right:
                MovementVector = new Vector3(moveDist, 0, 0);

                break;
            case MovementDirection.UpRight:
                MovementVector = new Vector3(moveDist / 2, 0, moveDist / 2);

                break;
            case MovementDirection.UpLeft:
                MovementVector = new Vector3(-moveDist, 0, moveDist);

                break;
            case MovementDirection.DownRight:
                MovementVector = new Vector3(moveDist, 0, -moveDist);

                break;
            case MovementDirection.DownLeft:
                MovementVector = new Vector3(-moveDist, 0, -moveDist);

                break;
            default:
                MovementVector = new Vector3(0, 0, 0);

                break;
        }

        return MovementVector;
    }

}
