using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public Item item;
    void Pickup(){
        Destroy(gameObject);
    }

    private void OnMouseDown(){
        Pickup();
    }
}
