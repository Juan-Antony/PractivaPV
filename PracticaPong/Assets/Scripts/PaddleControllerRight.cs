using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControllerRight : MonoBehaviour
{
    public float speed = 1f;
    public ControlType controlType;
    private bool isAI;
    private BallController ball;

    private void Start() {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if (!isAI)
            {
                isAI = true;
            } else
            {
                isAI = false;
            }
        }

        Vector3 newPosition = new Vector3(
            transform.position.x,
            Mathf.Clamp(
                GetNewYPosition(),
                -4.5f,
                4.5f
            ),
            transform.position.z
        );
        
        transform.position = newPosition; 
    }

    private float GetNewYPosition()
    {
        float result = transform.position.y;
        
        if (isAI)
        {
            if (BallIncoming())
            {
                result = Mathf.MoveTowards(transform.position.y, ball.transform.position.y, speed * Time.deltaTime);
            }
        } else
        {
            float inputMovement = controlType == ControlType.Keyboard
            ? Input.GetAxis("Vertical")
            : Input.GetAxis("Mouse Y");

            result = transform.position.y + (inputMovement * speed * Time.deltaTime);
        }
        return result;
    }

    private bool BallIncoming()
    {
        float enArea = -ball.transform.position.x;
        return enArea < 1f;
    }
}
