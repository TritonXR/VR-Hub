using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class SongManager : MonoBehaviour {

  //List of clips loaded into memory
  private List<AudioClip> clips;
    private List<string> songNames;

    public Text songText;

  //index of the active clip
  private int activeClip = 0;

  //TODO: whether or not we should load from the default music directory
  public bool LoadFromDefault = true;

    // Use this for initialization
  void Start () {

    //initialize list and load clips into list
    clips = new List<AudioClip>();
        songNames = new List<string>();
    StartCoroutine(LoadAudioFromWWW());

  }

  // Update is called once per frame
  void Update () {


	}

  /// <summary>
  /// Switches songs to the next in the list
  /// </summary>
  public void SwitchSongs() {

    //increment index and loop if necessary
    activeClip++;

    if (activeClip >= clips.Count) {

      activeClip = 0;

    }

    UpdateSong();
  
  }

  /// <summary>
  /// Updates the song
  /// </summary>
  public void UpdateSong() {

    //updates the current clip to the active clip and plays
    GetComponent<AudioSource>().clip = clips[activeClip];
    GetComponent<AudioSource>().Play();

  }


  /// <summary>
  /// Loads audio from a directory. Only works with .wav format
  /// </summary>
  IEnumerator LoadAudioFromWWW() {

    //directory to load files from
    string[] files = Directory.GetFiles("C:\\Users\\User\\Desktop\\M00sic");

    //loops through all files in the directory
    foreach(string str in files) {

      //checks the extension on the file
      if(Path.GetExtension(str) == ".wav") {

                songNames.Add(Path.GetFileNameWithoutExtension(str));
        //updates the path to load a WWW
        string clipString = "file://" + str;

        //loads the WWW (Whatever that means)
        WWW w = new WWW(clipString);
        
        //waits for the WWW to finish loading
        while (!w.isDone) {

          yield return null;

        }

        //Gets the audio clip from the WWW and adds to list
        AudioClip myClip = w.GetAudioClip(true);
        clips.Add(myClip);

      }

      else if (Path.GetExtension(str) == ".mp3") {

        //TODO: How to load .mp3 files?
        

      }

      else {

        Debug.LogWarning("File extension " + Path.GetExtension(str) + " is not supported");


      }
    }

        string songString = "";

        for (int i = 0; i < songNames.Count; i++) {

            songString += songNames[i] + "\n";


        }

        songText.text = songString;

        UpdateSong();

  }
}
