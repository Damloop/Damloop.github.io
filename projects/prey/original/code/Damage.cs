using UnityEngine;

public class Damage : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damageAmount = 10;

    // Applies damage to a target if it has a Health component
    private void OnTriggerEnter(Collider other)
    {
        Health targetHealth = other.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damageAmount);
        }
    }
}
