using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{

    [SerializeField] private ScreenFader screenFader;
    public void Play(){
        GetComponent<AudioSource>().Play();
        screenFader.FadeToColor("DungeonStart");
    }

    public void Quit(){
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}
