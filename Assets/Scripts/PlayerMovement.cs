using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask ground;
    [SerializeField] Animator animPlayerBody;
    [SerializeField] AudioSource audioSrcWalk;

    Rigidbody rigidbody;    
    float horizontal, vertical;
    Vector3 moveDirection;

    Vector2 screenPos;
    Ray mouseRay;
    RaycastHit hit;
    Vector3 mousePosInWorld;
    Health health;


	// Use this for initialization
	void Start ()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        health = GetComponent<Health>();
	}
	
	
	void FixedUpdate ()
    {
        if (health.isdeath) return;

        HorizontalVerticalMovement();//Keyboard awsd
        RotationMovement();//mouse

    }

    private void HorizontalVerticalMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical);

        
        rigidbody.MovePosition(transform.position + ((transform.forward * vertical) + (transform.right * horizontal)) * speed * Time.deltaTime);
        
        if(horizontal != 0f || vertical != 0f)
        {
            animPlayerBody.SetBool("run", true);
        }
        else
        {
            animPlayerBody.SetBool("run", false);
        }
        
    }
    private void RotationMovement()
    {
        
        screenPos = Input.mousePosition;        
        mouseRay = Camera.main.ScreenPointToRay(screenPos);
        

        if(Physics.Raycast(mouseRay, out hit, 100f, ground ))
        {
            mousePosInWorld = hit.point;
            Vector3 whereToLook = mousePosInWorld - this.transform.position;
            whereToLook.Set(whereToLook.x, 0f, whereToLook.z);
            rigidbody.MoveRotation(Quaternion.LookRotation(whereToLook));
        }
    }
    //below methods are called in the run animation
    public void StartWalkSound()
    {
        audioSrcWalk.Play();
    }
    public void StopWalkSound()
    {
        audioSrcWalk.Stop();
    }


}
