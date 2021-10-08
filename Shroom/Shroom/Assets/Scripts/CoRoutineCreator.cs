using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoRoutineCreator : MonoBehaviour
{
    public static CoRoutineCreator coRoutineCreator;
    void Start() {
        if (coRoutineCreator != null) {
            if (coRoutineCreator != this) {
                Destroy(gameObject);
            }
        } else {
            coRoutineCreator = this;
        }
    }
}
