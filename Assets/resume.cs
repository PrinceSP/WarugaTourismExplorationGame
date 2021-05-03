using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resume : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape)) {
        if (GameIsPaused) {
          Resume();
        }else{
          Pause();
        }
      }
    }

    public void Resume(){
      pauseMenuUi.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
      Cursor.visible = false;
    }

    void Pause(){
      pauseMenuUi.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu(){
      SceneManager.LoadScene("Menu");
    }

    public void QuitGame(){
      Application.Quit();
    }
}
