using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
//you spin me right round, spin me right round, like a record, baby, right round, round, round