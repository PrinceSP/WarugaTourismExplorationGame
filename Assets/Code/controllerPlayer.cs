using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerPlayer : MonoBehaviour
{
    // Rigidbody rb;
    CharacterController controller;
    public int speed=12;
    // Start is called before the first frame update
    void Start()
    {
      // rb = GetComponent<Rigidbody>();
      controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      float x = Input.GetAxis("Horizontal");
      float z = Input.GetAxis("Vertical");
      Vector3 move = new Vector3(x,0.0f,z);
      controller.Move(move*speed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other){
      if (other.gameObject.CompareTag("coinTag")) {
        other.gameObject.SetActive(false);
      }
    }
}
