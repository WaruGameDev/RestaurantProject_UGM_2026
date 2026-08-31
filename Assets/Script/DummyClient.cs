using UnityEngine;
using UnityEngine.AI;
public class DummyClient : MonoBehaviour
{
    public NavMeshAgent nav;
    public void ChooseTable()
    {
       
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChooseTable();
        }
    }
}
