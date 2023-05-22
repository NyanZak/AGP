using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TutorialManager : MonoBehaviour
{
    private bool moveTaskCompleted = false;
    private bool sprintTaskCompleted = false;
    private bool findCubeTaskCompleted = false;
    private bool moveCubeTaskCompleted = false;
    private bool transferPowerTaskCompleted = false;
    private bool transferPowerBackTaskCompleted = false;
    private bool bedTaskCompleted = false;
    private bool cabinetTaskCompleted = false;
    private bool lightswitchTaskCompleted = false;
    private bool isLightSwitchEnabled = false;
    private bool isPowerCubeInteractable = false;
    private bool isSprinting = false;
    private bool wKeyPressed = false;
    private bool aKeyPressed = false;
    private bool sKeyPressed = false;
    private bool dKeyPressed = false;
    private float sprintEndTime = 0f;
    private float sprintDelay = 0.5f;
    public GameObject powerCube;
    public GameObject nightstand;
    public GameObject player;
    public GameObject bed;
    public GameObject lightswitch;
    public TMP_Text tutorialText;
    public TMP_Text wKeyText;
    public TMP_Text aKeyText;
    public TMP_Text sKeyText;
    public TMP_Text dKeyText;
    public Image blackImage;
    private Color defaultKeyColor = Color.white;
    private Color pressedKeyColor = Color.green;
    public PowerCube powercube;
    private void Awake()
    {
        DisplayMessage("Use 'WASD' to move around.");
    }
    private void Start()
    {
        wKeyText.color = defaultKeyColor;
        aKeyText.color = defaultKeyColor;
        sKeyText.color = defaultKeyColor;
        dKeyText.color = defaultKeyColor;
        DisableLightSwitch();
    }
    private void Update()
    {
        if (!moveTaskCompleted)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                wKeyPressed = true;
                wKeyText.color = pressedKeyColor;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                aKeyPressed = true;
                aKeyText.color = pressedKeyColor;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                sKeyPressed = true;
                sKeyText.color = pressedKeyColor;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                dKeyPressed = true;
                dKeyText.color = pressedKeyColor;
            }
            if (wKeyPressed && aKeyPressed && sKeyPressed && dKeyPressed)
            {
                moveTaskCompleted = true;
                DisplayMessage("Press Left Shift to sprint.");
                wKeyText.gameObject.SetActive(false);
                aKeyText.gameObject.SetActive(false);
                sKeyText.gameObject.SetActive(false);
                dKeyText.gameObject.SetActive(false);
            }
        }
        else if (!sprintTaskCompleted)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSprinting = true;
                sprintEndTime = Time.time + sprintDelay;
            }
            if (isSprinting && Time.time >= sprintEndTime)
            {
                sprintTaskCompleted = true;
                DisplayMessage("Find the Power Cube in the level.");
            }
        }
        else if (!findCubeTaskCompleted)
        {
            if (Vector3.Distance(powerCube.transform.position, player.transform.position) < 1.5f)
            {
                findCubeTaskCompleted = true;
                DisplayMessage("Use the Mouse to move the Power Cube to the Nightstand");
            }
        }
        else if (!moveCubeTaskCompleted)
        {
            float distance = Vector3.Distance(powerCube.transform.position, nightstand.transform.position);
            if (distance < 2f)
            {
                moveCubeTaskCompleted = true;
                DisplayMessage("Press 'E' to transfer the power from the Power Cube");
            }
        }
        else if (!transferPowerTaskCompleted && Input.GetKeyDown(KeyCode.E) && Vector3.Distance(powerCube.transform.position, nightstand.transform.position) < 2f)
        {
            transferPowerTaskCompleted = true;
            DisplayMessage("Press 'E' to transfer the power back");
        }
        else if (!transferPowerBackTaskCompleted && Input.GetKeyDown(KeyCode.E) && Vector3.Distance(powerCube.transform.position, nightstand.transform.position) < 2f)
        {
            transferPowerBackTaskCompleted = true;
            DisplayMessage("Use the Power Cube to get on top of the Bed");
        }
        else if (!bedTaskCompleted && Vector3.Distance(player.transform.position, bed.transform.position) < 2.2f)
        {
            bedTaskCompleted = true;
            DisplayMessage("Use the mouse to open the Cabinet");
        }
        else if (!cabinetTaskCompleted && ScoreManager.instance.currentCoins > 0 )
        {
            cabinetTaskCompleted = true;
            EnableLightSwitch();
            DisplayMessage("Find a way to Power the Door to Open it");
        }
        else if (!lightswitchTaskCompleted && isLightSwitchEnabled  && isPowerCubeInteractable && Input.GetKeyDown(KeyCode.E) && Vector3.Distance(powerCube.transform.position, lightswitch.transform.position) < 2f)
        {
            lightswitchTaskCompleted = true;
            DisplayMessage("Exit to complete the tutorial");
        }
    }
    private void DisplayMessage(string message)
    {
        tutorialText.text = message;
        float textLength = tutorialText.preferredWidth;
        blackImage.rectTransform.sizeDelta = new Vector2(textLength, blackImage.rectTransform.sizeDelta.y);
    }

    private void EnableLightSwitch()
    {        
        lightswitch.SetActive(true);
        isLightSwitchEnabled = true;
        isPowerCubeInteractable = true;

    }
    private void DisableLightSwitch()
    {
        lightswitch.SetActive(false);
        isLightSwitchEnabled = false;
        isPowerCubeInteractable = false;

    }
}