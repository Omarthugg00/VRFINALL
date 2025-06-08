using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    public string correctPlaceholderTag;
    public Transform originalPosition;
    public AudioSource buzzSound;

    private bool isPlaced = false;

    void Start()
    {
        if (originalPosition == null)
            originalPosition = this.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isPlaced) return;

        if (other.CompareTag(correctPlaceholderTag))
        {
            // Snap to placeholder
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
            isPlaced = true;

            // Disable grabbing
            GetComponent<Collider>().enabled = false;
            GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().enabled = false;

            PuzzleManager.Instance.CubePlaced(); // Notify manager
        }
        else if (other.CompareTag("RedPlaceholder") || other.CompareTag("GreenPlaceholder") || other.CompareTag("BluePlaceholder"))
        {
            // Wrong spot
            if (buzzSound) buzzSound.Play();
            ReturnToOriginalPosition();
        }
    }

    void ReturnToOriginalPosition()
    {
        transform.position = originalPosition.position;
        transform.rotation = originalPosition.rotation;
    }
}
