using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DraggableItem : MonoBehaviour , IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public Image image;
    public GameObject objPrefab;

    private RectTransform rectTransform;

    [HideInInspector] public Transform parentAfterDrag;
    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {       
//        Debug.Log("OnBeginDrag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
  
    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log("OnDrag");
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {        
        //Debug.Log("OnEndDrag");
        transform.SetParent(parentAfterDrag);
        // image.raycastTarget = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(!Physics.Raycast(ray, out hit)) return;
            
       // GameObject obj = Instantiate(objPrefab, hit.point, Quaternion.identity);
       if(hit.collider.gameObject.CompareTag("area"))
       {
           GameObject obj = Instantiate(objPrefab, hit.point + new Vector3(0f, 1f, 0f), Quaternion.Euler(0f, 0f, 0f)); 
           obj.transform.localScale = new Vector3(1f, 1f, 1f);  
       }
    }
}