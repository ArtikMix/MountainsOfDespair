using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    public Canvas startMessage, allCanvas;
    bool hasInteracted = false;
    public Transform interactionTransform;
    private string trName;
    public virtual void Interact()
    {
        switch (trName)
        {
            case "Interaction": Debug.Log("Interacting with" + transform.name);
                break;
            case "DedBoxCollider":
                startMessage.gameObject.SetActive(true);
                allCanvas.gameObject.SetActive(false);
                break;
        }
    }
    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                trName = transform.name;
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
