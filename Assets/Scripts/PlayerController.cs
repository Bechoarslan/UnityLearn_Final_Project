using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float roatSpeed = 40;
    [SerializeField] private bool isGrounded;
    [SerializeField] private int jumpCounter;
    private Animator playerAnim;
    [SerializeField] float speed = 400;
    [SerializeField] float runSpeed = 600;
    
    [SerializeField] float jumpForce = 300;
    [SerializeField] bool isJumped;
    public float turnSpeed = 5;
    [SerializeField] float velocitySpeed;
    
   




    Rigidbody playerRb;
    // Start is called before the first frame update
   public  void Start()
    {
        
        
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        

        


    }

    // Update is called once per frame
    public void Update()
    { if(DestroyOnLoad.Instance.isStarted)
        {
            float y = Input.GetAxis("Mouse X") * turnSpeed;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
            playerRb.useGravity = enabled;
            Jump();

        }
       
        


       

        



    }
    public void FixedUpdate()
    {
        if (DestroyOnLoad.Instance.isStarted)
        {
            PlayerMove();
        }
        
        
    }




    public void OnMouseDrag()
    { if (!DestroyOnLoad.Instance.isStarted)
        {
            float rotX = Input.GetAxis("Mouse X") * roatSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * roatSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.up * rotX);
            transform.Rotate(Vector3.right * rotY);

        }


    }

    public void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (playerRb.velocity.magnitude < 5)
            {
                playerRb.AddRelativeForce(Vector3.forward * speed);
                playerAnim.SetFloat("Speed", 0.6f);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerRb.velocity = playerRb.velocity.normalized * 10;
                    playerRb.AddRelativeForce(Vector3.forward * runSpeed);
                    playerAnim.SetFloat("Speed", 1);



                }
            }





            




        }


        else if (Input.GetKey(KeyCode.S))
        {
            playerRb.AddRelativeForce(Vector3.back * speed);
            playerAnim.SetFloat("Speed", 0.6f);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRb.AddRelativeForce(Vector3.forward * runSpeed);
                playerAnim.SetFloat("Speed", 1);


            }


        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (playerRb.velocity.magnitude < 5)
            {


                playerRb.AddRelativeForce(Vector3.right * speed);
                playerAnim.SetBool("Right", true);
            }
        }

        else if (Input.GetKey(KeyCode.A))
        { if (playerRb.velocity.magnitude < 5)
            {
                playerRb.AddRelativeForce(Vector3.left * speed);
                playerAnim.SetBool("Right", true);
            }
        }
        else
        {
            if (isGrounded)
            {
                playerAnim.SetFloat("Speed", 0);
                playerRb.velocity = Vector3.zero;
                playerAnim.SetBool("Right", false);

            }
            

        }
    }
    


        


    

     
        
    
   
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCounter--;
            playerAnim.SetBool("Jump", true);



        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpCounter == 1)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            jumpCounter--;
            
           
            
            
            
        }
        
        else
        {
            playerAnim.SetBool("Jump", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCounter = 2;
            isJumped = false;
                
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumped = true;
        }
    }
}
