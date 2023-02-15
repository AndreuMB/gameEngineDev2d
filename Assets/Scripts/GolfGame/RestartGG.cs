using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class RestartGG : MonoBehaviour
{

    void Start () {
        gameObject.SetActive(false);
	}

	public void TaskOnClick(){
        // NetworkManager.SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
