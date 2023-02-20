using UnityEngine;

public class Pala : Tool
{

    public override void OnClickFunction(GameObject objetoClicado)
    {
        //TODO posibles animaciones en el futuro
        if (objetoClicado.tag == "Obstaculo") {
            Destroy(objetoClicado);
        }
    }
}
