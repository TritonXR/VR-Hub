using UnityEngine;
using System.Collections;

public class AutoResize : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void resize(GameObject ggg, float xxx){
		ggg.gameObject.transform.localScale += new Vector3(xxx,xxx,0);

		// adjust the position to make the picture centered at the same position
		// don't know why but seems multiple by 10 makes the picture approximately
		// remain at same center
		ggg.gameObject.transform.position = Vector3.MoveTowards(
			ggg.gameObject.transform.position,
			new Vector3(
			(ggg.gameObject.transform.position.x) - (xxx*10), 
			(ggg.gameObject.transform.position.y) - (xxx*10),
			0),
			9999999 * Time.deltaTime);
	}
}
