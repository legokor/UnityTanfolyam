using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
public class JatekosMozgas : PlayerController
{
    void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
    }
 
    void Update()
    {
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
 
        // Ide jön a vertikális sebesség számítása
        float curSpeedX = canMove ? walkSpeed * Input.GetAxis("Vertical") : 0;
        //
        //Ide jön a horizontális sebesség számítása
        float curSpeedY = canMove ? walkSpeed * Input.GetAxis("Horizontal") : 0;
        //


        float movementDirectionY = moveDirection.y;

        //Ide jön a mozgásvektor számítása a sebességek alapján
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        //

        #endregion
 
        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
 
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
 
        characterController.Move(moveDirection * Time.deltaTime);
        #endregion
 
        #region Handles Rotation
 
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
 
        #endregion
 
    }
}