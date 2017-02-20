using UnityEngine;
using System.Collections;

public class KittenBehaviour : MonoBehaviour {


    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        transform.position = new Vector3(0, 0, 0);
        //this.gameObject.SetActive(false);
    }
	
    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public void Walk()
    {
        animator.SetBool("waswalking", true);
        animator.SetTrigger("Walk");
    }

    public void Idle()
    {
        animator.SetBool("waswalking", false);
        animator.SetTrigger("Idle");
    }


}
