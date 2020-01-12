using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerArray;

    LevelController levelController;

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;         

    // Start is called before the first frame update
    IEnumerator Start()
    {
        levelController = FindObjectOfType<LevelController>();

        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();            
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void Spawn(Attacker attacker)
    {        
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    private void SpawnAttacker()
    {
        System.Random rnd = new System.Random();
        int attacker = rnd.Next(0, attackerArray.Length);

        Spawn(attackerArray[attacker]);
    }
}
