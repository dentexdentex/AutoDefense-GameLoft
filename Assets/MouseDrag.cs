using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDrag : MonoBehaviour //, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector3 turretInitialPos;
    private bool MoveMe;
    private void MyMouseDown()
    {
        turretInitialPos = transform.position;
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

    void MyOnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        if(!Physics.Raycast(ray, out hit)) return;
        if (hit.collider.gameObject.CompareTag("turret"))
        {
            return;
        }
        this.gameObject.transform.position = hit.point;
    }
    private void MyOnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(!Physics.Raycast(ray, out hit)) return;
        
        if(hit.collider.gameObject.CompareTag("area"))
        {
        this.gameObject.transform.position = hit.transform.position;
        }
        else
        {
            transform.position =turretInitialPos ;
        }
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
