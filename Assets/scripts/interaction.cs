using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interaction : MonoBehaviour
{

    List<string> likes = new List<string>();
    List<string> dislikes = new List<string>();
    //public AudioSource[] music = new AudioSource[6];
    public AudioSource currentSong;
    public AudioClip[] music = new AudioClip[6];
    public Button dislike;
    public Button like;
    int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        like.onClick.AddListener(() => {
            likes.Add(music[i].ToString());
            i++;
            playNext();
        });

        dislike.onClick.AddListener(() => {
            dislikes.Add(music[i].ToString());
            i++;
            playNext();
            
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
        if(i == 6) {
            
        }
    }
}
