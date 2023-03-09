using UnityEngine;

namespace Base
{
    public class BaseHealth : MonoBehaviour
    {
        public static BaseHealth Instance;
    
        public float currentBaseHealth=300;
        private float _damage = 25f;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        private void Start()
        {
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy"){ 
                TakeBaseDamage(_damage);
                Debug.Log(currentBaseHealth);
                Debug.Log(other.name);
            }
        }
        void TakeBaseDamage(float amount)
        {
            currentBaseHealth -= amount;
            if (currentBaseHealth <= 0f)
            {
                Time.timeScale = 0f;
                //gameObject.gameObject.transform.position = new Vector3(11000, 10001, 1000);
                // gameObject.SetActive(false);
            }
        }
    }
}
