using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerRio : InventoryController
{
    private GameObject semillaBeingUsed;

   protected override void PickUpSemilla(GameObject toolObject)
   {
        if (_tool == null)
        {
            base.PickUpSemilla(toolObject);
            semillaBeingUsed = toolObject;
            toolObject.gameObject.SetActive(false);
        }
        else if(_tool.GetComponent<Semilla>() != null && _tool.GetComponent<Semilla>().GetScriptablePlant().Equals(toolObject.GetComponent<Semilla>().GetScriptablePlant()))
        {
            base.PickUpSemilla(toolObject);
            Destroy(toolObject.gameObject);
        }

   }
    public override void UsarSemilla()
    {
        base.UsarSemilla();
        if (base.inventoryQty == 0)
        {
            Destroy(semillaBeingUsed.gameObject);
        }


    }
}
