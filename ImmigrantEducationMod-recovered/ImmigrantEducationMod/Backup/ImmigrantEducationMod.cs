// Decompiled with JetBrains decompiler
// Type: ImmigrantEducationMod.ImmigrantEducationMod
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;

namespace ImmigrantEducationMod
{
  public class ImmigrantEducationMod : IUserMod
  {
    private DataStore dataStore = DataStore.getInstance();
    public UITextField textAdultsEdu;
    public UITextField textYoungEdu;
    public UITextField textTeenEdu;
    public UITextField textSingleMin;
    public UITextField textSingleMax;
    public UITextField textFamilyMin;
    public UITextField textFamilyMax;

    public string Name
    {
      get
      {
        return "Customizable Immigrant Education";
      }
    }

    public string Description
    {
      get
      {
        return "Customize the education level of your city's settlers/immigrants, based on their age group";
      }
    }

    private void Save()
    {
      try
      {
        XML.WriteToBinaryFile(this.dataStore, false);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("error in saving to binary file" + (object) ex));
      }
    }

    public void ReloadXML()
    {
      XML.ReadFromBinaryFile();
      DataStore instance = DataStore.getInstance();
      this.textAdultsEdu.text = Convert.ToString(instance.eduChanceAdult);
      this.textYoungEdu.text = Convert.ToString(instance.eduChanceYoung);
      this.textTeenEdu.text = Convert.ToString(instance.eduChanceTeen);
      this.textSingleMin.text = Convert.ToString(instance.singleAge[0]);
      this.textSingleMax.text = Convert.ToString(instance.singleAge[1]);
      this.textFamilyMin.text = Convert.ToString(instance.familyAdultAge[0]);
      this.textFamilyMax.text = Convert.ToString(instance.familyAdultAge[1]);
    }

    private bool ValidateEduChance(string chance)
    {
      int int32 = Convert.ToInt32(chance);
      return int32 >= 0 && int32 <= 100;
    }

    private void SaveEduAdult(string c)
    {
      if (this.ValidateEduChance(c))
        this.dataStore.eduChanceAdult = Convert.ToInt32(c);
      this.textAdultsEdu.text = Convert.ToString(this.dataStore.eduChanceAdult);
    }

    private void SaveEduYoung(string c)
    {
      if (this.ValidateEduChance(c))
        this.dataStore.eduChanceYoung = Convert.ToInt32(c);
      this.textYoungEdu.text = Convert.ToString(this.dataStore.eduChanceYoung);
    }

    private void SaveEduTeen(string c)
    {
      if (this.ValidateEduChance(c))
        this.dataStore.eduChanceTeen = Convert.ToInt32(c);
      this.textTeenEdu.text = Convert.ToString(this.dataStore.eduChanceTeen);
    }

    private void SaveAgeSingleMin(string c)
    {
      int int32 = Convert.ToInt32(c);
      if (int32 >= 0)
        this.dataStore.singleAge[0] = int32;
      this.textSingleMin.text = Convert.ToString(this.dataStore.singleAge[0]);
    }

    private void SaveAgeSingleMax(string c)
    {
      int int32 = Convert.ToInt32(c);
      if (int32 <= (int) byte.MaxValue)
        this.dataStore.singleAge[1] = int32;
      this.textSingleMax.text = Convert.ToString(this.dataStore.singleAge[1]);
    }

    private void SaveAgeFamilyMin(string c)
    {
      int int32 = Convert.ToInt32(c);
      if (int32 >= 0)
        this.dataStore.familyAdultAge[0] = int32;
      this.textFamilyMin.text = Convert.ToString(this.dataStore.familyAdultAge[0]);
    }

    private void SaveAgeFamilyMax(string c)
    {
      int int32 = Convert.ToInt32(c);
      if (int32 <= (int) byte.MaxValue)
        this.dataStore.familyAdultAge[1] = int32;
      this.textFamilyMax.text = Convert.ToString(this.dataStore.familyAdultAge[1]);
    }

    public void OnSettingsUI(UIHelperBase helper)
    {
      if (!LoadingExtension.isModEnabled)
        XML.ReadFromBinaryFile();
      DataStore instance = DataStore.getInstance();
      UIHelper uiHelper1 = helper as UIHelper;
      ((UIHelper) uiHelper1.AddGroup("Save to XML file")).AddButton("Save", new OnButtonClicked(this.Save));
      UIHelper uiHelper2 = (UIHelper) uiHelper1.AddGroup("Reload those values in the XML file");
      uiHelper2.AddButton("Reload", new OnButtonClicked(this.ReloadXML));
      uiHelper2.AddGroup(string.Format("Invalid entries will be ignored by the mod!!{0}Please read the explanation below.", (object) System.Environment.NewLine));
      UIHelper uiHelper3 = (UIHelper) uiHelper1.AddGroup("Explanation of the values");
      uiHelper3.AddGroup("Chance of education that an incoming citizen will have is from 0 to 100, in percentage");
      uiHelper3.AddGroup(string.Format("Age range{0}{0}0~15 for children{0}15~45 for teens{0}45~90 for young adults{0}90~180 for adults{0}180~255 for seniors{0}You can set whatever value you want in the range of 0 to 255", (object) System.Environment.NewLine));
      UIHelperBase uiHelperBase1 = helper.AddGroup("Education Chances");
      this.textAdultsEdu = (UITextField) uiHelperBase1.AddTextfield("Adults chance to arrive Highly Educated", Convert.ToString(instance.eduChanceAdult), new OnTextChanged(this.SaveEduAdult), (OnTextSubmitted) null);
      this.textYoungEdu = (UITextField) uiHelperBase1.AddTextfield("Young adults chance to arrive Well Educated", Convert.ToString(instance.eduChanceYoung), new OnTextChanged(this.SaveEduYoung), (OnTextSubmitted) null);
      this.textTeenEdu = (UITextField) uiHelperBase1.AddTextfield("Teens chance to arrive Educated", Convert.ToString(instance.eduChanceTeen), new OnTextChanged(this.SaveEduTeen), (OnTextSubmitted) null);
      UIHelperBase uiHelperBase2 = helper.AddGroup("Age range");
      this.textSingleMin = (UITextField) uiHelperBase2.AddTextfield("Single adults age min", Convert.ToString(instance.singleAge[0]), new OnTextChanged(this.SaveAgeSingleMin), (OnTextSubmitted) null);
      this.textSingleMax = (UITextField) uiHelperBase2.AddTextfield("Single audlts age max", Convert.ToString(instance.singleAge[1]), new OnTextChanged(this.SaveAgeSingleMax), (OnTextSubmitted) null);
      this.textFamilyMin = (UITextField) uiHelperBase2.AddTextfield("Family adults age min", Convert.ToString(instance.familyAdultAge[0]), new OnTextChanged(this.SaveAgeFamilyMin), (OnTextSubmitted) null);
      this.textFamilyMax = (UITextField) uiHelperBase2.AddTextfield("Family adults age max", Convert.ToString(instance.familyAdultAge[1]), new OnTextChanged(this.SaveAgeFamilyMax), (OnTextSubmitted) null);
    }
  }
}
