using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ObjectToFollow;
    //Creates an offset for the camera
    public float FollowOffset = 3.12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0f, ObjectToFollow.transform.position.y + FollowOffset, -10f);
    }
}
