using UnityEngine;

namespace V
{
    public class LaughInteraction : MonoBehaviour
    {
        [SerializeField] private LayerMask LaughInteractableLayer;
        private EnemyBase enemyBase;

        private void OnTriggerEnter2D(Collider2D _other) 
        {
            if((LaughInteractableLayer.value & (1 << _other.gameObject.layer)) > 0)
            {
                enemyBase = _other.GetComponent<EnemyBase>();

                enemyBase.SetLaughStatus(true);
            }
        }

        private void OnTriggerExit2D(Collider2D _other) 
        {
            if((LaughInteractableLayer.value & (1 << _other.gameObject.layer)) > 0)
            {
                enemyBase = _other.GetComponent<EnemyBase>();

                enemyBase.SetLaughStatus(false);
            }          
        }
    }
}
