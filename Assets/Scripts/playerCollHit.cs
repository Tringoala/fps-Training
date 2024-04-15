using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            GameObject playerMain = gameObject;
            while (playerMain.name != "Player")
            {
                playerMain = playerMain.transform.parent.gameObject;
            }
            playerMain.GetComponent<playerControlComponent>().groundState(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            GameObject playerMain = gameObject;
            while (playerMain.name != "Player")
            {
                playerMain = playerMain.transform.parent.gameObject;
            }
            playerMain.GetComponent<playerControlComponent>().groundState(false);
        }
    }
}
