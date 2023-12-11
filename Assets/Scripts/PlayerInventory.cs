using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Enemyspawn enemyspawn;
    public int NumberOfParts { get; private set; }

    public void PartsCollected(){
        NumberOfParts++;
        print("Number of parts " + NumberOfParts);
        if (HasAllParts()) {
            enemyspawn.FinalWave();
        }
    }

    public bool HasAllParts() {
        return NumberOfParts >= 3;
    }
}
