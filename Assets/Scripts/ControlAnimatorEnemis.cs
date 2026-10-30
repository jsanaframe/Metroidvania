using UnityEngine;

public class ControlAnimatorEnemis : MonoBehaviour
{
    public void GoblinLanzaAttack()
    {
        transform.parent.GetComponent<GoblinController>().GoblinLanza();
    }
}
