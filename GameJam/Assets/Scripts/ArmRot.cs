using UnityEngine;

public class ArmRot : MonoBehaviour
{
    public int rotOffset = 90;

    void Update()
    {
        Vector3 differnce = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        differnce.Normalize();

        float rotZ = Mathf.Atan2(differnce.y, differnce.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotOffset);
    }
}
