using UnityEngine.SceneManagement;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Contract _contract;
    
    private void Update(){

        SkipCutscene();
        
        if (Input.GetKeyDown(KeyCode.Escape)){
            StopGame();
        }

        //Play the games intro or outro and then load the next scene
        if (_animator != null && _animator.GetCurrentAnimatorStateInfo(0).IsName("text_done")){
            SceneManager.LoadScene("Planet");
        }

        if (_animator != null && _animator.GetCurrentAnimatorStateInfo(0).IsName("reset")){
            ReturnToMainMenu();
        }
        
        if (_contract ==  null) return; 
        //Do stuff width contract
        
        if (_contract.moneyToReach <= Resources.current.money){
            SceneManager.LoadScene("outro"); 
        }
        
        if(_contract.GetTimeTillDeadline() <= 0 || Resources.current.getPopulation() <= 0){
            SceneManager.LoadScene("gameover");
        }
    }

    public void StartGame(){
        SceneManager.LoadScene("intro");
    }
 
    public void StopGame(){
        Application.Quit();
    }

    private static void ReturnToMainMenu(){
        SceneManager.LoadScene("mainMenu");
    }

    private static void SkipCutscene(){

        if(!Input.GetKeyDown(KeyCode.Space)) return;

        switch (GetCurrentSceneName()){
            case "intro":
                SceneManager.LoadScene("Planet");
                break;
            case "outro":
                SceneManager.LoadScene("mainMenu");
                break;
            case "gameover":
                SceneManager.LoadScene("mainMenu");
                break;
        }
    }

    private static string GetCurrentSceneName(){
        return SceneManager.GetActiveScene().name;
    }
    
}
