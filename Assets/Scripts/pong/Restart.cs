using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    void Start () {
        gameObject.SetActive(false);
	}

	public void TaskOnClick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
