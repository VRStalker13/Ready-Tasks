using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public static void CloseProgram()
    {
        Application.Quit();
    }
    
    public static void ToStartMenu()
    {
        SceneManager.LoadScene("Scenes/Start Menu");
    }

    public static void ToAddMenu()
    {
        SceneManager.LoadScene("Scenes/Add Human/Add Menu");
    }
    
    public static void ToAddStudent()
    {
        SceneManager.LoadScene("Scenes/Add Human/Add Student");
    } 
    
    public static void ToAddDriver()
    {
        SceneManager.LoadScene("Scenes/Add Human/Add Driver");
    } 
   
    public static void ToAddEmployer()
    {
        SceneManager.LoadScene("Scenes/Add Human/Add Employer");
    }
    
    public static void ToChooseHuman()
    {
        SceneManager.LoadScene("Scenes/Show Human/Choose Human");
    } 
    
    public static void ToChangeParamsList()
    {
        SceneManager.LoadScene("Scenes/Change Human/Change Params List");
    }  
    
    public static void ToShowHumans()
    {
        SceneManager.LoadScene("Scenes/Show Humans/Show Humans");
    }
 
    public static void ToDeleteHuman()
    {
        SceneManager.LoadScene("Scenes/Delete Human/Delete Human");
    } 
    
    public static void ToChangeProcess()
    {
        SceneManager.LoadScene("Scenes/Change Human/Change Process");
    } 
    
    public static void ToHumanInformation()
    {
        SceneManager.LoadScene("Scenes/Show Human/Human Inform");
    }
    
    public static void ToChangeHumanList()
    {
        SceneManager.LoadScene("Scenes/Change Human/Change Humans List");
    }
}
