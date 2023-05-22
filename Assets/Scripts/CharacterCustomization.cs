using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterCustomization : MonoBehaviour
{
    public GameObject[] hats, faces, armours, backpacks;
    public Material[] armourMaterials;
    private int currentHatIndex = 0;
    private int currentFaceIndex = 0;
    private int currentArmourIndex = 0;
    private int currentBackpackIndex = 0;
    private int currentArmourMaterialIndex = 0;
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        LoadCustomizationOptions();
        SetActiveCustomizationOption(hats, currentHatIndex);
        SetActiveCustomizationOption(faces, currentFaceIndex);
        SetActiveCustomizationOption(armours, currentArmourIndex);
        SetActiveCustomizationOption(backpacks, currentBackpackIndex);
        ApplyArmourMaterial(currentArmourMaterialIndex);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadCustomizationOptions();
        SetActiveCustomizationOption(hats, currentHatIndex);
        SetActiveCustomizationOption(faces, currentFaceIndex);
        SetActiveCustomizationOption(armours, currentArmourIndex);
        SetActiveCustomizationOption(backpacks, currentBackpackIndex);
        ApplyArmourMaterial(currentArmourMaterialIndex);
        SetBackpackActive();
    }
    public void ChangeHat()
    {
        Debug.Log(currentHatIndex);
        hats[currentHatIndex].SetActive(false);
        currentHatIndex = (currentHatIndex + 1) % hats.Length;
        SetActiveCustomizationOption(hats, currentHatIndex);
        SaveCustomizationOptions();
    }
    public void ChangeFace()
    {
        faces[currentFaceIndex].SetActive(false);
        currentFaceIndex = (currentFaceIndex + 1) % faces.Length;
        SetActiveCustomizationOption(faces, currentFaceIndex);
        SaveCustomizationOptions();
    }
    public void ChangeArmour()
    {
        armours[currentArmourIndex].SetActive(false);
        currentArmourIndex = (currentArmourIndex + 1) % armours.Length;
        currentArmourMaterialIndex = (currentArmourMaterialIndex + 1) % armourMaterials.Length;
        ApplyArmourMaterial(currentArmourMaterialIndex);
        armours[currentArmourIndex].SetActive(true);
        SaveCustomizationOptions();
    }
    public void ChangeBackpack()
    {
        backpacks[currentBackpackIndex].SetActive(false);
        currentBackpackIndex = (currentBackpackIndex + 1) % backpacks.Length;
        SetBackpackActive();
        SaveCustomizationOptions();
    }
    private void SetActiveCustomizationOption(GameObject[] options, int currentIndex)
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].SetActive(i == currentIndex);

        }
    }
    private void LoadCustomizationOptions()
    {
        if (PlayerPrefs.HasKey("HatIndex"))
            currentHatIndex = PlayerPrefs.GetInt("HatIndex");

        if (PlayerPrefs.HasKey("FaceIndex"))
            currentFaceIndex = PlayerPrefs.GetInt("FaceIndex");

        if (PlayerPrefs.HasKey("ArmourIndex"))
            currentArmourIndex = PlayerPrefs.GetInt("ArmourIndex");

        if (PlayerPrefs.HasKey("BackpackIndex"))
            currentBackpackIndex = PlayerPrefs.GetInt("BackpackIndex");

        if (PlayerPrefs.HasKey("ArmourMaterialIndex"))
            currentArmourMaterialIndex = PlayerPrefs.GetInt("ArmourMaterialIndex");
    }
    private void SaveCustomizationOptions()
    {
        PlayerPrefs.SetInt("HatIndex", currentHatIndex);
        PlayerPrefs.SetInt("FaceIndex", currentFaceIndex);
        PlayerPrefs.SetInt("ArmourIndex", currentArmourIndex);
        PlayerPrefs.SetInt("BackpackIndex", currentBackpackIndex);
        PlayerPrefs.SetInt("ArmourMaterialIndex", currentArmourMaterialIndex);
        PlayerPrefs.Save();
    }
    private void ApplyArmourMaterial(int materialIndex)
    {
        if (armours[currentArmourIndex].TryGetComponent<SkinnedMeshRenderer>(out var armorRenderer))
        {
            armorRenderer.material = armourMaterials[currentArmourMaterialIndex];
            for (int i = 0; i < armorRenderer.sharedMesh.subMeshCount; i++)
            {
                armorRenderer.materials[i] = armourMaterials[currentArmourMaterialIndex];
            }
        }
    }
    private void SetBackpackActive()
    {
        for (int i = 0; i < backpacks.Length; i++)
        {
            backpacks[i].SetActive(i == currentBackpackIndex);
        }
    }
}