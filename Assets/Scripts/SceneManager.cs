using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SceneManager : MonoBehaviour
{
    private const string ORIGINAL_GAME = "OriginalGame";

    public void PlayGame() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(ORIGINAL_GAME);
    }

    public void QuitGame()
    {
        if(Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else
          Application.Quit();
    }
}
