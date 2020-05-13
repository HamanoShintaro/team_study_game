using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace touch_game
{

    public class Spawner : MonoBehaviour
    {
        public GameObject prefabDog;
        public GameObject prefabCat;
        public GameObject prefabPenguin;
        public GameObject prefabLion;
        public GameObject prefabLadybug;
        public GameObject prefabDinosaur;
        public float coefficient;

        public bool spawnFlg = false;
        private float rand;

        private IEnumerator Start()
        {
            while (true)
            {
                if (this.spawnFlg)
                {
                    rand = Random.Range(0.0f,1.0f);
                    if (rand < 0.500f) { 
                        Instantiate(this.prefabDog, this.transform);
                        yield return new WaitForSeconds(Random.Range(2.0f, 4.0f) * coefficient);
                    }
                    else if(rand < 0.800f){
                        Instantiate(this.prefabCat, this.transform);
                        yield return new WaitForSeconds(Random.Range(2.0f, 4.0f) * coefficient);
                    }
                    else if(rand < 0.950f)
                    {
                        Instantiate(this.prefabPenguin, this.transform);
                        yield return new WaitForSeconds(Random.Range(1.5f, 3.0f) * coefficient);
                    }
                    else if (rand < 0.980f)
                    {
                        Instantiate(this.prefabLion, this.transform);
                        yield return new WaitForSeconds(Random.Range(1.5f, 3.0f) * coefficient);
                    }
                    else if (rand < 0.995f)
                    {
                        Instantiate(this.prefabLadybug, this.transform);
                        yield return new WaitForSeconds(Random.Range(2.0f, 4.0f) * coefficient);
                    }
                    else
                    {
                        Instantiate(this.prefabDinosaur, this.transform);
                        yield return new WaitForSeconds(Random.Range(2.0f, 4.0f) * coefficient);
                    }
                }
                else
                {
                    coefficient = 1;
                    yield return null;
                }
            }
        }

        public IEnumerator DestroyAllChildren()
        {
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Animal");
            yield return new WaitForSeconds(0.1f);
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
    }
}