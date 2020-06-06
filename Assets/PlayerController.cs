using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{


    //Brackeys
     public static Vector2 Position;
    // public float startMoveSpeed = 5f;
    // private float moveSpeed;
    // public float moveSmooth = .3f;
    // Vector2 movement = Vector2.zero;
    // Vector2 velocity = Vector2.zero;
     Vector2 mousePos = Vector2.zero;

        //thrustertutorial
    private Rigidbody2D rb;
    float maxVelocity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //thrustertutorial
        float Xaxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Thrust(yAxis, Xaxis);


        //Brackeys
        //movement.x = Input.GetAxis("Horizontal");
        //movement.y = Input.GetAxis("Vertical");
         mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //
        // transform.localScale = Vector3.one;// * Progression.Growth;
        // moveSpeed = startMoveSpeed; //* Progression.Growth;
    }

    #region Manouveour API


    //thrustertutorial
    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }
    //thrustertutorial
    private void Thrust(float forwardAmount,float sideWaysAmount)
    {
        Vector2 force = Vector2.up * forwardAmount + Vector2.right * sideWaysAmount ;

        rb.AddForce(force);
    }

    #endregion Manouveour API



    //Brackeys
    private void FixedUpdate()
    {
        // if (Progression.IsGrowing)
        // {
        //     rb.velocity = Vector2.zero;
        //     return;
        // }

        // Vector2 desiredVelocity = movement * moveSpeed;
        // rb.velocity = Vector2.SmoothDamp(rb.velocity, desiredVelocity, ref velocity, moveSmooth);


        // joystick mode
        if (Input.GetJoystickNames().Length > 0)
        {
            float Xaxis = Input.GetAxis("Horizontal2");
            float yAxis = Input.GetAxis("Vertical2");
            Debug.Log("X: "+Xaxis);
            Debug.Log("Y: " + yAxis);

            float angle = Mathf.Atan2(yAxis,Xaxis) * Mathf.Rad2Deg-90f;
            //Target.Set(target, 90, 0);
            //Quaternion rotation = Quaternion.LookRotation(Target);
            //transform.rotation = rotation;
            rb.rotation = angle;
            // transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            //Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
            //  float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            //  shootPoint.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

        }
        else
        { 
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }

        Position = rb.position;
    }




}
