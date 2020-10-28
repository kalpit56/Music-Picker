using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class interaction : MonoBehaviour
{

    List<string> likes = new List<string>();
    List<string> dislikes = new List<string>();

    public AudioSource currentSong;
    public AudioClip[] music = new AudioClip[8];

    public Texture[] images = new Texture[8];

    List<KeyValuePair<AudioClip, Texture>> songToImage = new List<KeyValuePair<AudioClip, Texture>>();

    public Button dislike;
    public Button like;
    public Button startOver;
    public Button start;

    public Text likeCount;
    public Text dislikeCount;
    public Text dislikeList;
    public Text likeList;

    public GameObject background;

    public Canvas startCanvas;
    public Canvas mainCanvas; 
    public Canvas endCanvas;

    int randomPicker;


    // Start is called before the first frame update
    void Start()
    {
        startCanvas.enabled = true;
        mainCanvas.enabled = false;
        endCanvas.enabled = false;

        for(int j = 0; j < music.Length; j++){
            KeyValuePair<AudioClip, Texture> pair = new KeyValuePair<AudioClip, Texture>(music[j], images[j]);
            songToImage.Add(pair);
        }

        start.onClick.AddListener(() => {
            randomPicker = Random.Range(0, songToImage.Count);
            startCanvas.enabled = false;
            mainCanvas.enabled = true; 
            playNext();
        });

        like.onClick.AddListener(() => {
            likes.Add(musicToString());
            likeCount.text = "Likes: " + likes.Count.ToString();
            adjust();
        });

        dislike.onClick.AddListener(() => {
            dislikes.Add(musicToString());
            dislikeCount.text = "Dislikes: " + dislikes.Count.ToString();
            adjust();
        });

        startOver.onClick.AddListener(() => {
            SceneManager.LoadScene(0); 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void adjust() {
        songToImage.RemoveAt(randomPicker);
        randomPicker = Random.Range(0, songToImage.Count);
        checkEnd();
        if(mainCanvas.enabled){
            playNext();
        }
    }
    
    string musicToString() {
        string musicString = songToImage[randomPicker].Key.ToString();
        musicString = musicString.Substring(0, musicString.IndexOf("UnityEngine.Audio")-1);
        return musicString;
    }


    void playNext() {
        currentSong.clip = songToImage[randomPicker].Key;
        currentSong.Play();
        background.GetComponent<RawImage>().texture = songToImage[randomPicker].Value;
    }

    void checkEnd(){
        if(songToImage.Count == 0) {
            mainCanvas.enabled = false;
            currentSong.Stop();
            endCanvas.enabled = true;
            displayEnd();     
        }
    }

    void displayEnd(){
        for(int i = 0; i < dislikes.Count; i++){
            dislikeList.text += "• " + dislikes[i] + "\n";
        }
        for(int j = 0; j < likes.Count; j++){
            likeList.text += "• " + likes[j] + "\n";
        }
    }

}
