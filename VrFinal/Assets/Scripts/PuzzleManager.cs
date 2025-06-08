using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public int placedCount = 0;
    public int totalToPlace = 3;

    public GameObject successUI;
    public AudioSource successSound;

    void Awake()
    {
        Instance = this;
    }

    public void CubePlaced()
    {
        placedCount++;

        if (placedCount >= totalToPlace)
        {
            successUI.SetActive(true);
            if (successSound) successSound.Play();
        }
    }

    public void RestartPuzzle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
