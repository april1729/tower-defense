using UnityEngine;
using System.Collections;

public static class Utilities
{
    public static void LookAt2D(Transform looker, Transform reciever)
    {
		float rot_z = Mathf.Atan2(reciever.transform.position.y-looker.transform.position.y, reciever.transform.position.x-looker.transform.position.x) * Mathf.Rad2Deg;
        looker.rotation = Quaternion.Euler(0f, 0f, rot_z-90);

    }
}
