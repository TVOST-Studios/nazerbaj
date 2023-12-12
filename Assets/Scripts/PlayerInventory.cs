using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Enemyspawn enemyspawn;
    public UI ui; // Reference to the UI script
    public int NumberOfParts { get; private set; }

    public void PartsCollected(){
    NumberOfParts++;
    print("Number of parts " + NumberOfParts);
    if (ui != null) {
        ui.CollectPart(); // Update the UI when a part is collected
    } else {
        Debug.LogError("UI is not assigned in PlayerInventory script.");
    }
    if (HasAllParts()) {
        enemyspawn.FinalWave();
    }
}


    public bool HasAllParts() {
        return NumberOfParts >= 3;
    }
}
