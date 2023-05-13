using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "PlayerSwim")
        {
            ScoreManager.instance.score++;
            Debug.Log("Fish Collected");
            Destroy(this.gameObject);
        }
    }
}
