using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    [SerializeField] float minTorque = 0.1f;
    [SerializeField] float maxTorque = 2.0f;
    [SerializeField] float throwStrength = 10.0f;

    private float DirX, DirY, DirZ;

    [SerializeField] TextMeshProUGUI diceroll;

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

        StartCoroutine(DiceSettled());
    }

    IEnumerator DiceSettled()
    {
        yield return new WaitForFixedUpdate();
        while(rb.angularVelocity.sqrMagnitude > 0.1)
        {
            yield return new WaitForFixedUpdate();
        }

        CheckDiceRoll();
    }

    public void CheckDiceRoll()
    {
        float x, y, z;

        x = Mathf.Round(Vector3.Dot(transform.right.normalized, Vector3.up));
        y = Mathf.Round(Vector3.Dot(transform.up.normalized, Vector3.up));
        z = Mathf.Round(Vector3.Dot(transform.forward.normalized, Vector3.up));


        if (gameObject.tag == "D6")
        {
            switch (x)
            {
                case 1:
                    Debug.Log("4");
                    diceroll.text = "4";
                    break;

                case -1:
                    Debug.Log("3");
                    diceroll.text = "3";
                    break;
            }

            switch (y)
            {
                case 1:
                    Debug.Log("2");
                    diceroll.text = "2";
                    break;

                case -1:
                    Debug.Log("6");
                    diceroll.text = "6";
                    break;
            }

            switch (z)
            {
                case 1:
                    Debug.Log("1");
                    diceroll.text = "1";
                    break;

                case -1:
                    Debug.Log("5");
                    diceroll.text = "5";
                    break;
            }
        }

        if (gameObject.tag == "D4")
        {
            switch (x)
            {
                case -1:
                    Debug.Log("4");
                    break;
            }

            switch (y)
            {
                case 1:
                    Debug.Log("2");
                    break;

                case -1:
                    Debug.Log("3");
                    break;
            }

            switch (z)
            {
                case 1:
                    Debug.Log("1");
                    break;
            }
        }

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
