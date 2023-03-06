using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 10f;
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    private void Update()
    {
        // Düşmanları tespit etmek için taretinizin etrafında bir alan oluşturun.
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        // Taretinizin menzilindeki düşmanları kontrol edin.
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                // Düşmanınızı hedef olarak ayarlayın.
                target = collider.transform;
                
                // Taretinizin hedefe doğru dönmesini sağlayın.
                Vector3 direction = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                
                // Taretinizin ateş etmesini sağlayın.
                if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }
                fireCountdown -= Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
        // Mermi nesnesini oluşturun ve ateş edin.
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null){}
     //       bullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        // Taretinizin menzilini görsel olarak temsil edin.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
