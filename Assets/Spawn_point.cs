using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_point : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

    public void Spawn(Enemy game) => Instantiate(game, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);

}
