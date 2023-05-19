using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public Animator visorAnimator;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private bool isWalking;
    private bool isRunning;

    public AudioSource walkingVisorAudioSource;
    public AudioSource runningVisorAudioSource;
    public AudioSource walkingAudioSource;
    public AudioSource runningAudioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        visorAnimator = transform.Find("VisorPivot").GetComponent<Animator>(); 

        walkingVisorAudioSource = transform.Find("WalkingAudioSource").GetComponent<AudioSource>(); 
        runningVisorAudioSource = transform.Find("RunningAudioSource").GetComponent<AudioSource>(); 


    }

    private void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical);
            if (direction.magnitude > 0)
            {
                float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
                isWalking = moveSpeed == walkSpeed;
                isRunning = moveSpeed == runSpeed;
                transform.rotation = Quaternion.LookRotation(direction);
                moveDirection = direction * moveSpeed;
                if (isWalking)
                {
                    if (!walkingVisorAudioSource.isPlaying)
                    {
                        walkingVisorAudioSource.Play();
                    }
                    if (!walkingAudioSource.isPlaying)
                    {
                        walkingAudioSource.Play();
                    }
                }
                else if (isRunning)
                {
                    if (!runningVisorAudioSource.isPlaying)
                    {
                        runningVisorAudioSource.Play();
                    }
                    if (!runningAudioSource.isPlaying)
                    {
                        runningAudioSource.Play();
                    }
                }
            }
            else
            {
                isWalking = false;
                isRunning = false;
                walkingVisorAudioSource.Stop();
                runningVisorAudioSource.Stop();
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        visorAnimator.SetBool("isWalking", isWalking);
        visorAnimator.SetBool("isRunning", isRunning);
    }
}
