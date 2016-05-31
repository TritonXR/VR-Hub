using UnityEngine;
using System.Collections;

public class WhiteboardScript : MonoBehaviour {

    private Vector3 lastHitPoint;
    public Object linePiece;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Ray castRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        Vector3 lineStartPoint = Vector3.zero;

        if(Physics.Raycast(castRay, out hitInfo, Mathf.Infinity)) {

            Whiteboard hitBoard = hitInfo.collider.gameObject.GetComponent<Whiteboard>();

            if(hitBoard) {

                if(Input.GetMouseButton(0)) {

                    Debug.Log("HIT");

                    lineStartPoint = hitInfo.point;

                    if(lastHitPoint == Vector3.zero) lastHitPoint = lineStartPoint;

                    Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    GameObject newLine = (GameObject)GameObject.Instantiate(linePiece);
                    LineRenderer newLineRenderer = newLine.GetComponent<LineRenderer>();

                    newLineRenderer.SetPosition(0, lastHitPoint);
                    newLineRenderer.SetPosition(1, lineStartPoint);
                    newLineRenderer.SetWidth(0.1f, 0.1f);
                }

            }

        }

        lastHitPoint = lineStartPoint;
    }
}
