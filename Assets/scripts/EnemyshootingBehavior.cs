using System.Collections;
using UnityEngine;

public class EnemyShootingBehaviour : MonoBehaviour
{
    public GameObject target;
    public float shotRange = 10f;
    public float coolDownTime = 2f;

    private bool inCooldown = false;
    private Shoot shootScript;
    private TriggerAnimation triggerAnimationScript;

    void Start()
    {
        shootScript = GetComponentInChildren<Shoot>();
        triggerAnimationScript = GetComponentInChildren<TriggerAnimation>();
    }

    void Update()
    {
    
        if (target == null) return;

        Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPos);

        Vector3 delta = transform.position - target.transform.position;

        if (delta.magnitude < shotRange && !inCooldown)
        {
            shootScript.CallShot();
            //triggerAnimationScript.CallTrigger();
            inCooldown = true;
            StartCoroutine(Cooldown(coolDownTime));
        }
    }

    private IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        inCooldown = false;
    }
}