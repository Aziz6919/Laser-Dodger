using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineRendererDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LineRenderer laserbeam;
    [SerializeField] Transform StartPoint;
    [SerializeField] Transform EndPoint;
    [SerializeField] LayerMask layerMask;
    void Start()
    {
        laserbeam = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        if (laserbeam.positionCount < 2)
        {
            Debug.LogWarning("LineRenderer does not have enough points.");
            return;
        }

       /* Vector3 startPoint = laserbeam.GetPosition(0);
        Vector3 endPoint = laserbeam.GetPosition(1);*/

        Vector3 direction = EndPoint.position-StartPoint.position;
        float distance = direction.magnitude;

        Ray ray = new Ray(StartPoint.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                GameManager.Instance.GameOver();
                Debug.Log("Player detected!");
                // Add your logic here when the player is detected
            }
        }

        // For debugging purposes, you can visualize the ray in the Scene view
       
        Debug.DrawRay(StartPoint.position, direction, Color.green);
       
    }
}
