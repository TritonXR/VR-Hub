using UnityEngine;
using System.Collections;

public class GrabandThrow : MonoBehaviour {

    FixedJoint grabJoint;
    bool objectDetect;
    private GameObject detectedObj;
    private Transform attachPoint;

    void Start()
    {
        attachPoint = GameObject.Find("AttachPoint").transform;
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Object Touched");
        objectDetect = true;
        detectedObj = collider.gameObject;
    }

    void OnTriggerExit(Collider collider)
    {
        objectDetect = false;
        Debug.Log("No Object Detected");
    }

    void GrabDetectedObject(GameObject obj)
    {
        obj.transform.position = attachPoint.position;
        grabJoint = obj.AddComponent<FixedJoint>();
        grabJoint.connectedBody = attachPoint;

    }

    void FixedUpdate()
    {
        if (objectDetect == true && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Grab Attempted");
            GrabDetectedObject(detectedObj);
        }
    }
}
