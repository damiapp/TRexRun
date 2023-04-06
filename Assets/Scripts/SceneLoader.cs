using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 




public class SceneLoader : MonoBehaviour
{
    private const string ORIGINAL_GAME = "OriginalGame";

    public void PlayGame() 
    {
        SceneManager.LoadScene(ORIGINAL_GAME);
    }

    public void QuitGame()
    {
        if(Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else
          Application.Quit();
    }
}
