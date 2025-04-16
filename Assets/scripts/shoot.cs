using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject prefab;
    public KeyCode shootKey = KeyCode.LeftControl;
    public float delay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            CallShot();
        }
    }

    public void CallShot()
    {
        StartCoroutine(AwaitDelay(delay));
    }

    private IEnumerator AwaitDelay(float time)
    {
        yield return new WaitForSeconds(time);
        createProjectile();
    }
    private void createProjectile()
    {
        GameObject ob = Instantiate(prefab);
        ob.transform.rotation = transform.rotation;
        ob.transform.position = transform.position + transform.forward;
        Destroy(ob, 3f);
    }
}
