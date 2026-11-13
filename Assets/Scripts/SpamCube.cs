using UnityEngine;

public class SpamCube : MonoBehaviour
{
    private float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            Destroy(gameObject);
        }
    }
}
