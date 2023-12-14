using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public GameObject objective1;
    public GameObject objective2;
    public Button nextLvlBtn;
    public AudioSource sound;
    public GameObject stageClearedPanel;
    public GameObject GameStart;

    // Start is called before the first frame update
    void Start()
    {
        nextLvlBtn.onClick.AddListener(NextLvl);
        sound = GetComponent<AudioSource>();
    }

    public void NextLvl()
    {
        sound.Play();
        stageClearedPanel.SetActive(false);
        GameStart.SetActive(true);
        objective1.SetActive(false);
        objective2.SetActive(true);
    }
}
