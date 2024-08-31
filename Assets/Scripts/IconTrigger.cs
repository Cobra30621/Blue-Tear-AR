using UnityEngine;

/// <summary>
/// This script controls the fading in and out of an icon's transparency.
/// </summary>
public class IconTrigger : MonoBehaviour
{
    private Material fadeMaterial;
    private MeshRenderer meshRenderer;
    public float fadeDuration = 2f;
    private float fadeTimer;
    private bool isFadingIn;

    private void Start()
    {
        // Get the MeshRenderer and Material components of the game object.
        meshRenderer = GetComponent<MeshRenderer>();
        fadeMaterial = meshRenderer.material;

        // Set the initial transparency of the icon to 0.
        fadeMaterial.color = new Color(fadeMaterial.color.r, fadeMaterial.color.g, fadeMaterial.color.b, 0);

        // Start fading in.
        isFadingIn = false;
    }

    private void Update()
    {
        // Increment the fade timer.
        fadeTimer += Time.deltaTime;

        if (isFadingIn)
        {
            // Lerp the transparency from 0.5 to 1 over the fade duration.
            float alpha = Mathf.Lerp(0.5f, 1, fadeTimer / fadeDuration);
            fadeMaterial.color = new Color(fadeMaterial.color.r, fadeMaterial.color.g, fadeMaterial.color.b, alpha);

            // If the fade timer has reached the fade duration, reset the timer and start fading out.
            if (fadeTimer >= fadeDuration)
            {
                fadeTimer = 0;
                isFadingIn = false;
            }
        }
        else
        {
            // Lerp the transparency from 1 to 0.5 over the fade duration.
            float alpha = Mathf.Lerp(1, 0.5f, fadeTimer / fadeDuration);
            fadeMaterial.color = new Color(fadeMaterial.color.r, fadeMaterial.color.g, fadeMaterial.color.b, alpha);

            // If the fade timer has reached the fade duration, reset the timer and start fading in.
            if (fadeTimer >= fadeDuration)
            {
                fadeTimer = 0;
                isFadingIn = true;
            }
        }
    }
}