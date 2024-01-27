using UnityEngine;

namespace V
{
    public class LaughInteraction : MonoBehaviour
    {
        private EnemyBase enemyBase;
        private void Awake() 
        {
            enemyBase = GetComponentInParent<EnemyBase>();    
        }

        private void OnTriggerEnter2D(Collider2D _other) 
        {
            if(_other.gameObject.tag == "Player")
            {
                enemyBase.SetLaughStatus(true);
            }
        }

        private void OnTriggerExit2D(Collider2D _other) 
        {
            if(_other.gameObject.tag == "Player")
            {
                enemyBase.SetLaughStatus(false);
            }            
        }
    }
}
