using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class GrabandThrow : MonoBehaviour {

    public float throwVelocity = 10.0f;

	bool objectDetect;
	private GameObject detectedObj;
    private SteamVR_TrackedObject trackedController;
    private SteamVR_Controller.Device device;

    private Rigidbody attachPoint;
    private FixedJoint attachJoint;

    void Awake()
	{
        trackedController = GetComponent<SteamVR_TrackedObject>();
	}
        
    void CreateAttachPoint()
    {
        attachPoint = transform.GetChild(0).Find("tip").GetChild(0).GetComponent<Rigidbody>(); 
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

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedController.index);
        GrabThrowDetectedObject(detectedObj);
    }

    void GrabThrowDetectedObject(GameObject obj)
    {
        if (objectDetect == true)
        {
            if (attachJoint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                CreateAttachPoint();
                obj.transform.position = attachPoint.transform.position;
                attachJoint = obj.AddComponent<FixedJoint>();
                attachJoint.connectedBody = attachPoint;    
            }
            else if (attachJoint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Destroy(attachJoint);
                attachJoint = null;
            }
        }
    }
}
