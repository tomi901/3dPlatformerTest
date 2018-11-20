using UnityEngine;


public abstract class Collectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            OnCollect(player);
            Destroy(gameObject);
        }
    }

    protected abstract void OnCollect(Player player);

}
