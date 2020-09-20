using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float cubesize = 0.2f;
    public int cubeinrow = 5;
    float cubepivotdistance;
    Vector3 cubespivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    private void Start()
    {
        cubepivotdistance = cubesize * cubeinrow / 2;
        cubespivot = new Vector3(cubepivotdistance, cubepivotdistance, cubepivotdistance);
    }

    private void OnCollisionEnter(Collision collisioninfo)
    {

        if (collisioninfo.collider.tag == "obstacle")
        {
            explode();
        }
    }
    void explode()
    {
        gameObject.SetActive(false);
        for (int x=0; x < cubeinrow; x++)
        {
            for(int y=0; y < cubeinrow; y++)
            {
                for(int z=0; z<cubeinrow; z++)
                {
                    createpiece(x, y, z);
                }
            }
        }
        Vector3 explosionpos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionpos,explosionRadius);
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createpiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = transform.position + new Vector3(cubesize * x, cubesize * y, cubesize * z)-cubespivot;
        piece.transform.localScale = new Vector3(cubesize, cubesize, cubesize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubesize;

        Material material = piece.GetComponent<Renderer>().material;
        material.color = Color.red;
    }
}
