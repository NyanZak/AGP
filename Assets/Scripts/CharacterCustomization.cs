using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    public GameObject[] hats, faces, armours, backpacks;
    public Material[] armourMaterials;
    private int currentHatIndex = 0;
    private int currentFaceIndex = 0;
    private int currentArmourIndex = 0;
    private int currentBackpackIndex = 0;
    private int currentArmourMaterialIndex = 0;
   
    void Start()
    {
        SetActiveCustomizationOption(hats, currentHatIndex);
        SetActiveCustomizationOption(faces, currentFaceIndex);
        SetActiveCustomizationOption(armours, currentArmourIndex);
        SetActiveCustomizationOption(backpacks, currentBackpackIndex);
    }
    public void ChangeHat()
    {
        hats[currentHatIndex].SetActive(false);
        currentHatIndex = (currentHatIndex + 1) % hats.Length;
        SetActiveCustomizationOption(hats, currentHatIndex);
    }
    public void ChangeFace()
    {
        faces[currentFaceIndex].SetActive(false);
        currentFaceIndex = (currentFaceIndex + 1) % faces.Length;
        SetActiveCustomizationOption(faces, currentFaceIndex);
    }
    public void ChangeArmour()
    {
        armours[currentArmourIndex].SetActive(false);
        currentArmourMaterialIndex = (currentArmourMaterialIndex + 1) % armourMaterials.Length;
        SkinnedMeshRenderer armorRenderer = armours[currentArmourIndex].GetComponent<SkinnedMeshRenderer>();
        armorRenderer.material = armourMaterials[currentArmourMaterialIndex];
        for (int i = 0; i < armorRenderer.sharedMesh.subMeshCount; i++)
        {
            armorRenderer.materials[i] = armourMaterials[currentArmourMaterialIndex];
        }
        armours[currentArmourIndex].SetActive(true);
    }
    public void ChangeBackpack()
    {
        backpacks[currentBackpackIndex].SetActive(false);
        currentBackpackIndex = (currentBackpackIndex + 1) % backpacks.Length;
        SetActiveCustomizationOption(backpacks, currentBackpackIndex);
    }
    private void SetActiveCustomizationOption(GameObject[] options, int currentIndex)
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (i == currentIndex)
            {
                options[i].SetActive(true);
            }
            else
            {
                options[i].SetActive(false);
            }
        }
    }
}