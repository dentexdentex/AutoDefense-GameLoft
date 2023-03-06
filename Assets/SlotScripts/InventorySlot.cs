
using UnityEngine;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("yerleşitirdşi");
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggebleItem = dropped.GetComponent<DraggableItem>();
        draggebleItem.parentAfterDrag = transform;
    }
}
