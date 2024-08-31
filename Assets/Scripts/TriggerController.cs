using UnityEngine;

/// <summary>
/// Controls the behavior of child game objects based on trigger events.
/// </summary>
public class TriggerController : MonoBehaviour
{
    /// <summary>
    /// Sets all child game objects active.
    /// </summary>
    public void Show()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Sets all child game objects inactive.
    /// </summary>
    public void Close()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}