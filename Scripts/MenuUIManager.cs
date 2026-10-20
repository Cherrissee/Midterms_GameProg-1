using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    public void GameSceneUILoad() {
        SceneManager.LoadScene("Game_Scene");
    }

}
