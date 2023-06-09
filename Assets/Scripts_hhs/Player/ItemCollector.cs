using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cherriesText;
    [SerializeField] private TextMeshProUGUI gemsText;
    [SerializeField] private float delay = .4f;
    private Animator animator;
    private int cherries = 0;
    private int gems = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("cherry"))
        {
            animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("GetItem");
            cherries++;
            cherriesText.text = cherries.ToString();
            Destroy(collision.gameObject, delay);
            AudioManager.instance.PlayEnvironmentSfx("Collect_Cherry");
        }
        if (collision.gameObject.CompareTag("gem"))
        {
            animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("GetItem");
            gems++;
            gemsText.text = gems.ToString();
            Destroy(collision.gameObject, delay);
            AudioManager.instance.PlayEnvironmentSfx("Collect_Gem");
        }
    }
}
