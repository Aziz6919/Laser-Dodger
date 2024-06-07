using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{



    // Start is called before the first frame update
    [SerializeField] Transform Playertransform;
    [SerializeField] Transform CameraFollowpoint;
    Vector3 Velocity = Vector3.zero;
    Animator CameraAnimator;
    void Start()
    {
        CameraAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        carfollow();
    }

    void carfollow()
    {
        transform.LookAt(Playertransform);
        transform.position = Vector3.SmoothDamp(transform.position, CameraFollowpoint.position, ref Velocity,
            5 * Time.deltaTime);
    }

    public void disableAnimator()
    {
        CameraAnimator.enabled = false;
    }
}
