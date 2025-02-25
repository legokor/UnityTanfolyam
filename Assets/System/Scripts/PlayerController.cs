using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Camera playerCamera; 
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
 
 
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    protected static PlayerController instance;
    public static PlayerController Player{
        get{
            if (instance == null){
                instance = FindFirstObjectByType<PlayerController>();
            }
            return instance;
        }
    }
    void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            UnityEngine.Debug.Log("Respawn");
            this.GetComponent<CharacterController>().enabled = false;
            var pos = TaskController.Instance.currentTask.spawnPoint.position;
            UnityEngine.Debug.Log("pos: " + pos);
            transform.position = new Vector3(
                pos.x,
                pos.y,
                pos.z
            );
            this.GetComponent<CharacterController>().enabled = true;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            UnityEngine.Debug.Log("Respawn");
            var pos = TaskController.Instance.currentTask.spawnPoint.position;
            UnityEngine.Debug.Log("pos: " + pos);
            transform.position = new Vector3(
                pos.x,
                pos.y,
                pos.z
            );
        }
    }
 
    protected Vector3 moveDirection = Vector3.zero;
    protected float rotationX = 0;
 
    public bool canMove = true;
 
    
    protected CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 
    void Update()
    {
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
 
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
 
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
 
        #endregion
 
        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);
 
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
 
        #endregion
    }

    public void GoTo(Vector3 pos){
        GetComponent<CharacterController>().enabled = false;
        transform.position = pos;
        GetComponent<CharacterController>().enabled = true;
    }
}