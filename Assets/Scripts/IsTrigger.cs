using UnityEngine;

public class IsTrigger : MonoBehaviour
{
    public bool isTrigger;
    public Collider otherGameObject;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bolt"))
        {
            isTrigger = true;
            otherGameObject = other;
        }
    }
}
