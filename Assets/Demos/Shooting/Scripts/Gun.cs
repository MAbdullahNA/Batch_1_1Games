using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera _camera;

    public int range = 50;
    public int damage = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.GetComponent<EnemyHealth>())
            { hit.transform.GetComponent<EnemyHealth>().UpdateHealth(-damage); }
        }
    }
}
