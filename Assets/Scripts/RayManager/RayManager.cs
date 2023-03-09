using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RayManager : MonoBehaviour
{
    // public LayerMask layerMask; // Raycast'ın sadece belirli layerlardaki objeleri tespit etmesini sağlar.
    // public string draggableTag = "draggable"; // Drag and drop yapılabilen objelerin tag ismi.
    // public string targetTag = "target"; // Hedef objelerin tag ismi.
    // public bool isDragging = false; // Drag işlemi yapıldığı zaman true, aksi takdirde false olur.
    // public GameObject objectBeingDragged; // Drag işlemi yapılan obje.

    private TurretManager _turretManager;
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(!Physics.Raycast(ray, out hit)) return;
            if (hit.collider.TryGetComponent(out TurretManager turretManager))
            {
                _turretManager = turretManager;
                turretManager.Down();
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (_turretManager != null)
            {
               _turretManager.Drag();
            }
        }
     
        if (Input.GetMouseButtonUp(0))
        {
            if (_turretManager != null)
            {
                _turretManager.Up();
            }
            _turretManager = null;

        }
    }
}
