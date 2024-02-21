using UnityEngine;

public class VizsgaMozgas : PlayerController {
    void Update()
    {
        #region Handles Movment
        Vector3 elore = transform.TransformDirection(Vector3.forward);
        Vector3 jobbra = transform.TransformDirection(Vector3.right);
 
        // X és Y tengelyen való elmozdulás

        
        //
        
        
        float mozgasVektor = moveDirection.y;
        //Egyesített mozgásvektor

        //

        #endregion
 
        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = mozgasVektor;
        }
 
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //Mozgás a mozgásvektorral, idő függvényében

        //

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