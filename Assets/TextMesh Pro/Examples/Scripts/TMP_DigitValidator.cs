#region Assembly TextMeshPro-1.0.55.2017.2.0b12, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// D:\IDE\Unity\Projects\Moonsharp Playground\Dance Dance Dance\Assets\TextMesh Pro\Plugins\TextMeshPro-1.0.55.2017.2.0b12.dll
#endregion

using UnityEngine;
using System;


namespace TMPro
{
    /// <summary>
    /// EXample of a Custom Character Input Validator to only allow digits from 0 to 9.
    /// </summary>
    [Serializable]
    //[CreateAssetMenu(fileName = "InputValidator - Digits.asset", menuName = "TextMeshPro/Input Validators/Digits", order = 100)]
    public class TMP_DigitValidator : TMP_InputValidator
    {
        // Custom text input validation function
        public override char Validate(ref string text, ref int pos, char ch)
        {
            if (ch >= '0' && ch <= '9')
            {
                pos += 1;
                return ch;
            }

            return (char)0;
        }
    }
}
