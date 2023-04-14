using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerRio : InventoryController
{
    private GameObject semillaBeingUsed;

   protected override void PickUpSemilla(GameObject toolObject)
   {
        if (base.inventoryQty == 0)
        {
            base.PickUpSemilla(toolObject);
            semillaBeingUsed = toolObject;
            toolObject.gameObject.SetActive(false);
        }
        else
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
