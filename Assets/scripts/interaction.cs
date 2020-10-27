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

    public Button dislike;
    public Button like;
    public Button startOver;

    public Text likeCount;
    public Text dislikeCount;
    public Text dislikeList;
    public Text likeList;

    public GameObject background;

    public Canvas startCanvas; 
    public Canvas endCanvas;

    int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        background.GetComponent<RawImage>().texture = images[i];
        startCanvas.enabled = true;
        endCanvas.enabled = false;

        like.onClick.AddListener(() => {
            string musicString = music[i].ToString();
            musicString = musicString.Substring(0, musicString.IndexOf("UnityEngine.Audio")-1);
            likes.Add(musicString);
            likeCount.text = "Likes: " + likes.Count.ToString();
            checkEnd();
            if(startCanvas.enabled){
                i++;
                background.GetComponent<RawImage>().texture = images[i];
                playNext();
            }
        });

        dislike.onClick.AddListener(() => {
            string musicString = music[i].ToString();
            musicString = musicString.Substring(0, musicString.IndexOf("UnityEngine.Audio")-1);
            dislikes.Add(musicString);
            dislikeCount.text = "Dislikes: " + dislikes.Count.ToString();
            checkEnd();
            if(startCanvas.enabled){
                i++;
                background.GetComponent<RawImage>().texture = images[i];
                playNext();
            }
        });

        startOver.onClick.AddListener(() => {
            SceneManager.LoadScene(0); 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void playNext() {
        currentSong.clip = music[i];
        currentSong.Play();
    }

    void checkEnd(){
        if(i == 7) {
            startCanvas.enabled = false;
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
