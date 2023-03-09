using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//Bu script ray managera çekildi kulllanılmıyor
public class MouseDrag : MonoBehaviour //, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private Vector3 _screenPoint;
    private Vector3 _offset;

    private Vector3 _turretInitialPos;
    private bool _moveMe;

    private void Start()
    {
        _moveMe = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MyMouseDown();
        }

        if (Input.GetMouseButton(0))
        {
            MyOnMouseDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            MyOnMouseUp();
        }
    }
    private void MyMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        if(!Physics.Raycast(ray, out hit)) return;
        if (hit.collider.gameObject == this.gameObject)
        {
            _moveMe = true;
            return;
        }
        _turretInitialPos = transform.position;
    }

    void MyOnMouseDrag()
    {

        if (_moveMe)
        {
            var nextPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(transform.position).z);
            var worldPos = Camera.main.ScreenToWorldPoint(nextPos);
            transform.position = new Vector3(worldPos.x, transform.position.y, worldPos.z);
           
        }
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;
        // // screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // // offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        // if(!Physics.Raycast(ray, out hit)) return;
        // if (hit.collider.gameObject == this.gameObject)
        // {
        //     return;
        // }
        // transform.position = hit.point;
    }
    private void MyOnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(!Physics.Raycast(ray, out hit)) return;
        
        if(hit.collider.gameObject.CompareTag("area"))
        {
            transform.position = hit.transform.position;
        }
        else
        {
            transform.position =_turretInitialPos ;
        }

        _moveMe = false;
    }
}

    
    
    
    
    
    
    //private RectTransform rectTransform;
    // void OnMouseDrag()
    // {
    //     Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.2f);
    //     Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //     transform.position = objPosition;
    // }
    
    
    
    // public void Start()
    // {
    //     rectTransform = GetComponent<RectTransform>();
    // }
    // public void OnBeginDrag(PointerEventData eventData)
    // {       
    //     Debug.Log("OnBeginDrag");
    //   
    // }
    // public void OnDrag(PointerEventData eventData)
    // {
    //     Debug.Log("OnDrag");
    //     transform.position = Input.mousePosition;
    // }
    //
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //     if (!Physics.Raycast(ray, out hit)) return;
    //     if (hit.collider.gameObject.CompareTag("area"))
    //     {        
    //         transform.position = Input.mousePosition;
    //     }
    // }
