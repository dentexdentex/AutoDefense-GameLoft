using UnityEngine;
public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float _currentHealth;
    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0f)
        {
            gameObject.gameObject.transform.position = new Vector3(11000, 10001, 1000);
          gameObject.SetActive(false);
        }
    }
}