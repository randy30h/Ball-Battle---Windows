using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Camera cam;
    public GameObject playerChar;
    public GameObject foeChar;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "FoeRegion")
                {
                    Instantiate(foeChar, hit.point, Quaternion.identity);
                }

                if (hit.transform.name == "PlayerRegion")
                {
                    Instantiate(playerChar, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
