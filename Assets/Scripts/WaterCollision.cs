using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Contains("Player"))
        {
            PlayerController controller = col.GetComponent<PlayerController>();
            controller.jump = controller.jumpAmount;
        }
    }
}
