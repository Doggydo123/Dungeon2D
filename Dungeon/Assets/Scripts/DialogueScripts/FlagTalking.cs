using UnityEngine;

public class OptionBoxManager : MonoBehaviour
{
    public static bool isOptionBoxOpen = false; // Flag variable to indicate if the option box is open

    public GameObject[] flagHolder; // Reference to the flag holder GameObject

    // Method to raise the flag
    public void RaiseFlag()
    {
        isOptionBoxOpen = true; // Set the flag to true when the option box is opened
    }

    // Method to lower the flag
    public void LowerFlag()
    {
        isOptionBoxOpen = false; // Set the flag to false when the option box is closed
    }

    void Update()
    {
        if (flagHolder != null)
        {
            foreach (GameObject flag in flagHolder)
            {
                if (flag.activeSelf)
                {
                    RaiseFlag();
                    return;
                }
            }
        }
        LowerFlag();
    }
}
