using UnityEngine.Audio;
using UnityEngine;

public class AudioManageExample : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {

        DataStruct d = new DataStruct();
        d.p = 4;

        // mod(d);

        // print(d.p);

        int a = 7;
        mod(ref a);

        print(a);
        
    }

    void mod(ref int d) {
        d = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    class DataClass {
        public int p;
    }
    
    struct DataStruct {
        public int p;

    }

}
