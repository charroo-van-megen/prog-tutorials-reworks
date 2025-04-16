using UnityEngine;
using System.Collections;

public class TriggerAnimation : MonoBehaviour
{
    public string triggerName;
    public float delay = 0f;
    public float resetTime = 1f;
    public KeyCode triggerKey = KeyCode.None;

    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(triggerKey)) {
            CallTrigger();
        }
    }

    public void CallTrigger()
    {
        StartCoroutine(AwaitDelay(delay));
        StartCoroutine(AwaitReset(resetTime));
    }

    private IEnumerator AwaitDelay(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetTrigger(triggerName);
        if (audioSource != null) audioSource.Play();
    }

    private IEnumerator AwaitReset(float time)
    {
        yield return new WaitForSeconds(time);
        animator.ResetTrigger(triggerName);
    }
}
