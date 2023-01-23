using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
    }
}
