using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Rendering;

public class BallController : MonoBehaviour
{
 private Rigidbody _rb;
 [SerializeField] float speed;
 [SerializeField]  float fallingSpeed; 

 private bool _isGrounded;
 private float depth;

 private bool _movingX;
 private bool _movingZ;  
 void Start()
 {
  _rb = GetComponent<Rigidbody>();
  depth = GetComponent<Collider>().bounds.size.y;

  _movingX = true;
  _movingZ = true; 

 }

 void Update()
 {
  CheckGround(); 
 }

 void FixedUpdate()
 {

  if (_movingX = true && Input.GetKeyDown(KeyCode.Mouse0))
  {
   MovementXAxis();
   _movingZ = false; 
  }

  if (_movingZ = true && Input.GetKeyDown(KeyCode.Mouse1))
  {
   MovementZAxis();
   _movingX = false; 
  }
  
  Fall();
  
 }

 void MovementXAxis()
 {
  _movingX = true; 
  _rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
 }
 
 void MovementZAxis()
 {
  _movingZ = true; 
  _rb.AddForce(Vector3.forward * speed, ForceMode.Impulse); 
 }

 private void CheckGround()
 {
  _isGrounded = Physics.Raycast(transform.position, Vector3.down, depth);
 }

 public void Fall()
 {
  if (!_isGrounded)
  {
   _rb.AddForce(Vector3.down * fallingSpeed, ForceMode.Impulse); 
  }
 }

 private int gem = 0;

 private void OnTriggerEnter(Collider other)
 {
  if(other.transform.tag == "gem")
  {
   gem++; 
   Debug.Log("Score: " + gem);
   Destroy(other.gameObject);
  }
}
 
 
}