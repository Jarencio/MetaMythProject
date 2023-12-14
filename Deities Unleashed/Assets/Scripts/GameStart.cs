using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject panel;
    public Button play;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        play.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Debug.Log("click");
        sound.Play();
        panel.SetActive(false);
    }
}
