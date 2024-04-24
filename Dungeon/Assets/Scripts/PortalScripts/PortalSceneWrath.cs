using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSceneWrath : MonoBehaviour
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

    public void EnterWrathDungeon()
    {
        // Load the Dungeon Scene
        SceneManager.LoadScene("Dungeon 1 Wrath");
    }

    public void CloseOptionBox()
    {
        // Close the option box UI
        optionBoxUI.SetActive(false);
    }
}