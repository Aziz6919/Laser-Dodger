using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player Prapeties")]
    public float MoveSpeed = 5f;
    [SerializeField] Rigidbody rigidBody=null;
    [SerializeField] private float turnSpeed = 200;
    [SerializeField] float JumpForce = 10f;
    [SerializeField] FixedJoystick joystick;
    [Header("Player jump details")]
    private bool jump = false;
    private bool isGrounded;

    [Header("Animator")]
    [SerializeField] private Animator animator=null;
    [Header("Player colliders")]
    private List<Collider> m_collisions = new List<Collider>();

    private void Awake()
    {
        if (!animator) { animator = GetComponent<Animator>(); }
        if (!rigidBody) { rigidBody=GetComponent<Rigidbody>(); }
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetTrigger("Land");
        }
        
    }
    public void Move()
    {
       Vector3 direction = new Vector3(joystick.Horizontal * MoveSpeed*Time.deltaTime, rigidBody.velocity.y,
        joystick.Vertical * MoveSpeed*Time.deltaTime);
        direction.Normalize();
        transform.Translate(direction, Space.World);
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed*Time.deltaTime);
        }
        //animator.SetFloat("MoveSpeed", direction.magnitude);

    }

    public void Jump()
    {
        rigidBody.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
    }
}
