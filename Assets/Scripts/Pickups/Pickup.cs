using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotatonSpeed = 100f;

    const string playerString = "Player";

    private void Update()
    {
        transform.Rotate(0f, rotatonSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup();
}
