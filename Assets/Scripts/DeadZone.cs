using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{   
    [SerializeField]
    private GameObject _respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }

            CharacterController kontrol = other.GetComponent<CharacterController>();

            if( kontrol != null)
            {
                kontrol.enabled = false;
            }
            other.transform.position = _respawnPoint.transform.position;

            /* if(kontrol != null)
               {
                  kontrol.enabled = true;
               }
            */

            StartCoroutine(kontrolEnableRoutine(kontrol));
        }
    }

    IEnumerator kontrolEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
