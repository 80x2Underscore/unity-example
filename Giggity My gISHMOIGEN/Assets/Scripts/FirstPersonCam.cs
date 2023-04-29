using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FirstPersonCam : MonoBehaviour
{
   public Camera PlayerCamera;
   public float walkSpeed = 6f;
   public float runSpeed = 12f;
   public float jumpPower = 7f;
   public float gravity = 10f;

   public float lookSpeed = 2f;
   public float lookXLimit = 45f;

   Vector3 moveDirection = Vector3.zero;
   float rotationX = 0;

   public bool canMove = true;
   CharacterController characterController;
}
void Start()
{
    CharacterController = GetComponenent<CharacterController>();
    Curser.lockstate = CurserLockMode.Locked;
    Curser.visible = false;

}
void Update()
{
    #region Handles Movement
    Vector3 forward = transform.TransformDirection(Vector3.forward);
    Vector3 right = transform.TransformDirection(Vector3.right);

    //Running Mechanic
    bool isRunning = Input.GetKey(KeyCode.LeftShift);
    float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.getAxis("Vertical") : 0;
    float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.getAxis("Horizontal") : 0;
    float moveDirectionY = moveDirection.y;
    moveDirection = (forward * curSpeedX) + (right * curSpeedY);

    #endregion

    #region Handles Jumping
    if (Input.GetButton("Jump") && canMove && characterController.IsGrounded)
    {
        moveDirection.y = jumpPower;
    }
    else
    {
        moveDirection.y = moveDirectionY;

    }
    if (!characterController.IsGrounded)
    {
        moveDirection.y -= gravity * Time.deltaTime;
    }
    #endregion

    #region Handles Rotation
    CharacterController.Move(moveDirection * Time.deltaTime);

    if(canMove)
    {
        rotationX += -Input.getAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        PlayerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotation *= Quaternion.Euler(0, Input.getAxis("Mouse X") * lookSpeed, 0);

    }
    #endregion
}
