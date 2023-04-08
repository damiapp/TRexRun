using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 




public class SceneLoader : MonoBehaviour
{
    private const string ORIGINAL_GAME = "OriginalGame";
    private const string UPGRADED_GAME = "UpgradedGame";
    public PlayerData playerData;

    public void PlayGame() 
    {
        SceneManager.LoadScene(ORIGINAL_GAME);
        playerData.highScore = 0;
    }

    public void PlayUpgradedGame()
    {
        SceneManager.LoadScene(UPGRADED_GAME);
        playerData.highScore = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
