using UnityEngine;

public class MagneticWall : MonoBehaviour
{
    public float snapDistance = 1.5f; // Distance d'attraction
    public Vector3[] snapOffsets = new Vector3[] // Offsets possibles pour aligner les murs
    {
        new Vector3(1, 0, 0),  // Mur à droite
        new Vector3(-1, 0, 0), // Mur à gauche
        new Vector3(0, 0, 1),  // Mur devant
        new Vector3(0, 0, -1)  // Mur derrière
    };

    private void Update()
    {
        MagneticWall[] walls = FindObjectsOfType<MagneticWall>();
        foreach (var otherWall in walls)
        {
            if (otherWall != this)
            {
                TrySnapToWall(otherWall);
            }
        }
    }

    void TrySnapToWall(MagneticWall otherWall)
    {
        foreach (Vector3 offset in snapOffsets)
        {
            Vector3 targetPosition = otherWall.transform.position + offset;
            if (Vector3.Distance(transform.position, targetPosition) < snapDistance)
            {
                transform.position = targetPosition;
                transform.rotation = otherWall.transform.rotation;
                return; // Empêche d'attacher à plusieurs murs à la fois
            }
        }
    }
}
