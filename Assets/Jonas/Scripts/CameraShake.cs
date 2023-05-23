using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.1f;

    public AudioSource audioSource;

    private float shakeTimer;

    private void Update()
    {
        // Check if the shake duration has elapsed
        if (shakeTimer > 0f)
        {
            // Generate a random offset for the camera position
            Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;

            // Apply the offset to the camera's position
            transform.localPosition = randomOffset;

            // Decrease the shake timer
            shakeTimer -= Time.deltaTime;
        }
    }

    public void ShakeCamera()
    {
            audioSource.Play();
        // Set the shake timer to the duration
        shakeTimer = shakeDuration;
    }
}
