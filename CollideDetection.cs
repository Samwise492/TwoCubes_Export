using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetection : MonoBehaviour
{
    public bool isTouchedGround, isTouchedFinish, gameEnd;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Block")
            isTouchedGround = false;
        else if (col.gameObject.tag != "Block" && col.gameObject.tag == "Ground")
            isTouchedGround = true;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            isTouchedFinish = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Block")
            if (isTouchedGround)
                gameEnd = true;
    }
}
