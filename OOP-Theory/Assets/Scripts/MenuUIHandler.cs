using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{

    [field: SerializeField] private TMP_InputField InputFieldName{ get; set; }
    

    void Start(){
        InputFieldName.onEndEdit.AddListener(SubmitName);
    }

    public void StartNew(int sceneNumber){
        switch(sceneNumber){
            case 1:
                var op = SceneManager.LoadSceneAsync(1);
                op.completed += (x) => {
                    MainManager.Instance.VariablesInit();
                };
                break;
            default:
                Debug.Log("Error Couldn't load scene");
                break;
        }
    }
    public void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        MainManager.Instance.PlayerName = arg0;
        StartNew(1);
    }
}
