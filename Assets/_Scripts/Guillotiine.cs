using UnityEngine;

public class Guillotine : MonoBehaviour
{

    public float fuerza = 300f;        // fuerza del motor
    public float velocidadMax = 100f;  // velocidad máxima de oscilación
    public float frecuencia = 2f;      // cuántas veces por segundo cambia de dirección
    private HingeJoint hinge;
    JointMotor motor;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useMotor = true;
        motor = hinge.motor;
        motor.force = fuerza;
    }
    void FixedUpdate()
    {
        float velocidad = Mathf.Sin(Time.time * frecuencia) * velocidadMax;
        motor.targetVelocity = velocidad;
        hinge.motor = motor;
    }
}





