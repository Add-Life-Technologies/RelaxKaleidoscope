/////////////////////////////////////////////////////////////////////////////////////////////
//
//	ERMP_Player.cs
//	© Artem Goldov (Mugle Studio). All Rights Reserved.
//	http://www.mugle.ru
//
//	Description: "Easy Random Music Playlist" - the simplest solution to create and control backgound music in game.
//
/////////////////////////////////////////////////////////////////////////////////////////////


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ERMP_Player : MonoBehaviour
{

    public enum Music_Mode //GUI Types

    {
        BackgroundAtStart,
        Trigger
    }
    
    //Info
    [Header("Easy Random Music Playlist v1.0", order = 1)]

    public Music_Mode MusicMode = Music_Mode.BackgroundAtStart;
    public string TagName = "Background_Music";

    [Space(15)]

    [Header("Choose your music:", order = 2)]

    public Object[] Music; // declare this as Object array

    public AudioSource PlayerAudio;
    private string MusicModeControl = "";

    void Start()
    {

        PlayerAudio = gameObject.GetComponent<AudioSource>();

        switch (MusicMode)
        {            
            case Music_Mode.Trigger:

                MusicModeControl = "Trigger";

                break;

            case Music_Mode.BackgroundAtStart:

                MusicModeControl = "BackgroundAtStart";

                break;
        }

        if (PlayerAudio != null)
        {         

        if (!PlayerAudio.isPlaying && MusicModeControl == "BackgroundAtStart") { playRandomMusic(); }  
                      
        }
        else
        {

        Debug.LogError("ERMP_Player: You need to add AudioSource!");

        }
    }

    public void playRandomMusic()
    {

        Random.InitState((int)System.DateTime.Now.Ticks);

        PlayerAudio.clip = Music[Random.Range(0, Music.Length)] as AudioClip; // We select random music

        PlayerAudio.Play(); // Play the selected music

    }

    void OnTriggerStay(Collider PlayerCollision) // Collision by tag
    {
                if (PlayerCollision.tag == TagName && PlayerAudio != null && MusicModeControl == "Trigger")
                {
                    playRandomMusic();
                    Destroy(PlayerCollision.gameObject); // Destroy Trigger from game world

                }
                else
                {

                    //Debug.LogError("ERMP_Player: You need to add AudioSource!");

                }     
    }

}


