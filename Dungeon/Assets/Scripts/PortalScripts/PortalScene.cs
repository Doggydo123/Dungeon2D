using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScene : MonoBehaviour
{
    public GameObject optionBoxUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Display option box UI
            optionBoxUI.SetActive(true);
        }
    }

    public void EnterDungeon()
    {
        // Load the Dungeon Scene
        SceneManager.LoadScene("Dungeon");
    }

    public void CloseOptionBox()
    {
        // Close the option box UI
        optionBoxUI.SetActive(false);
    }
}