using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlType
{
    Keyboard, Mouse
}

public class PaddleControllerLeft : MonoBehaviour
{
    public float speed = 1f;
    public ControlType controlType;

    private void Update()
    {
        float inputMovement = controlType == ControlType.Keyboard
            ? Input.GetAxis("Vertical")
            : Input.GetAxis("Mouse Y");
        
        Vector3 newPosition = new Vector3(
            transform.position.x,
            Mathf.Clamp(
                transform.position.y + (inputMovement * speed * Time.deltaTime),
                -4.5f,
                4.5f
            ),
            transform.position.z
        );
        
        transform.position = newPosition; 
    }
}
