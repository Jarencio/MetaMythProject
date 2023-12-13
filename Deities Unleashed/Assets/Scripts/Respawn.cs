using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public void RestartLevel()
    {
        PlayerPrefs.SetInt("SavedLevel", FindObjectOfType<CharacterLevelSystem>().currentLevel);
        PlayerPrefs.SetInt("SavedExp", FindObjectOfType<CharacterLevelSystem>().currentExp);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
