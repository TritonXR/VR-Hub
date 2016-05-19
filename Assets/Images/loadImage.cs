using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class loadImage : MonoBehaviour {

	// the url or path to the image
	string url = "file:///Users/kk442021907/Desktop/ABC.png";
	Texture2D img;
	Sprite theSprite;

	// Use this for initialization
	void Start () {

		// load image from beginning
		StartCoroutine (LoadImg ());
		// Sprite foo = Sprite.Create (img, new Rect (0, 0, img.width, img.height), new Vector2 ());


	}

	// the function to convert Texture2D to Sprite
	void convertSprite(){
		Rect rec = new Rect(0,0, img.width, img.height);
     	theSprite = Sprite.Create(img, rec, new Vector2());
	}

	IEnumerator LoadImg(){
		yield return 0;
		WWW imgLink = new WWW (url);
		yield return imgLink;
		img = imgLink.texture;

		// create a plane
		GameObject plane1 = new GameObject("NewObject");


		convertSprite();     // convert img to sprite and store in theSprite
		plane1.AddComponent<SpriteRenderer> ();   // add SpriteRenderer to attach sprite
		plane1.GetComponent<SpriteRenderer>().sprite = theSprite;

		/*
		string[] files = Directory.GetFiles ("/User/kk442021907/Desktop");

		foreach (string str in files) {
			if (Path.GetExtension (str) == ".png") {
				
			}
		
		}*/
	}


	// Update is called once per frame
	void OnGUI () {
		//GUILayout.Label (img);
	}
}
	
