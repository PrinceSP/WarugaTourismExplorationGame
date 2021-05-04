using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    private int counter;
    public float sensitivity;
    public Text coinText;
    public AudioSource asource;
    public AudioClip aclip;
    // public AudioClip jumpClip;

    // Rigidbody rb;
    CharacterController controller;
    Animator characterAnimator;
    private bool isMoving = false;
    private bool isRunning = false;
    private bool isJumping = false;
    private bool onStairs = false;
    // Use this for initialization
    void Start()
    {
      // rb = GetComponent<Rigidbody>();
      controller = GetComponent<CharacterController>();
      characterAnimator = GetComponent<Animator>();
      counter = 23;
      coinText.text= "Remaining: " + counter;
    }

    void FixedUpdate()
    {
        // if (controller.isGrounded){
        //     //Feed moveDirection with input.
        //
        // }
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        //Multiply it by speed.
        moveDirection *= speed;
        //Jumping
        isJumping = false;
        if (Input.GetButton("Jump")){
          isJumping = true;
          TurnOffAnimations();
          characterAnimator.SetBool("Jump",true);
          moveDirection.y = jumpSpeed*1.5f;
          // asource.PlayOneShot(jumpClip);
        }

        turner = Input.GetAxis("Mouse X") * sensitivity;
        looker = -Input.GetAxis("Mouse Y") * sensitivity;

        if (turner != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        if (looker != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(looker, 0, 0);
        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && controller.isGrounded && !isJumping) {
          isMoving = false;
          TurnOffAnimations();
          characterAnimator.SetBool("Idle",true);
        }

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0) {
          isMoving = true;
        }

        if (isMoving == true && !isRunning && !isJumping) {
          TurnOffAnimations();
          characterAnimator.SetBool("Walkiing",true);
        }

        if (isMoving==true && !isJumping && Input.GetButton("Fire3")) {
          speed = 14;
          TurnOffAnimations();
          characterAnimator.SetBool("Running",true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
          isRunning = false;
          speed = 6;
        }
    }

    void TurnOffAnimations(){
      AnimationClip[] animClips = characterAnimator.runtimeAnimatorController.animationClips;
      foreach(AnimationClip clip in animClips){
        characterAnimator.SetBool(clip.name, false);
      }
    }
    private void OnTriggerEnter(Collider other){
      if (other.gameObject.CompareTag("coinTag")) {
        other.gameObject.SetActive(false);
        counter--;
        coinText.text = "Remaining: " + counter;
        asource.PlayOneShot(aclip);
      }
    }
}
