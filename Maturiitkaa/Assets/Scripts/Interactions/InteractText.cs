using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{
    private bool _interact;
    [SerializeField] private TMP_Text ownTextField;
    [SerializeField] private WritingGameplay writing;
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        writing.ChangeTextArea(ownTextField);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        writing.UseDefaultTextArea();
    }
}
