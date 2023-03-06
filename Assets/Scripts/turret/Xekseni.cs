using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xekseni : MonoBehaviour
{
    public Transform targetTransform; // Hedef transform
    public float rotationSpeed = 10f; // Nesnenin dönüş hızı
    public void Xeksen( Transform x)
    {
      //   Vector3 direction = targetTransform.position - transform.position; // Yönü hesapla
      // //  direction.y = 0f; // Sadece x ekseninde dönmek için yükseklik değerini sıfırla
      //   Quaternion targetRotation = Quaternion.LookRotation(direction); // Yönü döndürme açısına dönüştür
      //   transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
      // // Döndürme işlemini yap
      transform.LookAt(x);
    } 
}

