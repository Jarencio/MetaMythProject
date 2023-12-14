using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddOns : MonoBehaviour
{

    public AudioSource sound;
    public GameObject objectives;
    public Button objectiveBtn1;
    public GameObject objectiveBtn11;
    public Button objectiveBtn2;
    public GameObject objectiveBtn22;
    public void Start()
    {
        sound = GetComponent<AudioSource>();
        objectiveBtn1.onClick.AddListener(OnClickObj);
        objectiveBtn2.onClick.AddListener(OnClickObjAgain);
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnClickObjAgain2();
        }
    }
    public void OnClick()
    {
        Debug.Log("click");
        sound.Play();

    }

    public void OnClickObj()
    {
        sound.Play();
        objectiveBtn11.SetActive(false);
        objectiveBtn22.SetActive(true);
        objectives.SetActive(true);
    }

    public void OnClickObjAgain()
    {
        sound.Play();
        objectiveBtn11.SetActive(true);
        objectiveBtn22.SetActive(false);
        objectives.SetActive(false);
    }
    public void OnClickObjAgain2()
    {
        objectiveBtn11.SetActive(true);
        objectiveBtn22.SetActive(false);
        objectives.SetActive(false);
    }
}
