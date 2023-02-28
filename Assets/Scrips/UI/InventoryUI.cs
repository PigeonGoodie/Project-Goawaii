using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI glitterDropText;

    // Start is called before the first frame update
    void Start()
    {
        glitterDropText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateGlitterDropText (PlayerInventoryGlitter playerInventory)
    {
        glitterDropText.text = playerInventory.NumberOfGlitterDrop.ToString();
    }
   
}
