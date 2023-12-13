using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D20Roller : MonoBehaviour
{
    [SerializeField] float minTorque;
    [SerializeField] float maxTorque;
    [SerializeField] float throwStrength;

    private float DirX, DirY, DirZ;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void RollDice()
    {
        DirX = Random.Range(minTorque, maxTorque);
        DirY = Random.Range(minTorque, maxTorque);
        DirZ = Random.Range(minTorque, maxTorque);

        rb.AddForce(Vector3.up * throwStrength, ForceMode.Impulse);
        rb.AddTorque(DirX, DirY, DirZ);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }
    }
}
