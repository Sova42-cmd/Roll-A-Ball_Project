using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
//why tf does this goddamn idiotic truckload of shit doesn't work