using System.Collections.Generic;
using System.IO;
using System;
namespace SwipeSwipeMania
{
    // A class for reading various MSD like file contents.
    // Format: #param0:param1:param2:param3:param4;
    // Note that everything between # and ; count as a single 'value'
    // First parameter is usually an indentifier, but doesn't necessarily have to be.
    // Reference: https://github.com/stepmania/stepmania/blob/master/src/MsdFile.h
    public class MsdFile
    {
        List<Value> values;

        public MsdFile()
        {
            values = new List<Value>();
        }

        public bool ReadFile(string filepath, bool unescape)
        {
            if (File.Exists(filepath))
            {
                ReadBuf(File.ReadAllText(filepath), unescape);
                return true;
            }
            return false;
        }

        public void ReadFromString(string content, bool unescape)
        {
            ReadBuf(content, unescape);
        }

        public int GetNumValues()
        {
            return values.Count;
        }

        public int GetNumParams(int val)
        {
            if (val >= GetNumValues())
                throw new IndexOutOfRangeException();
            return values[val].Parameters.Count;
        }

        public Value GetValue(int i)
        {
            if (i < 0 || i > values.Count)
                throw new System.IndexOutOfRangeException();
            else return values[i];
        }


        // Function derives from cpp (*char buff,int len)
        private void ReadBuf(string content, bool unescape)
        {
            values.Capacity = 64;
            bool ReadingValue = false;
            char[] Processed = new char[content.Length];
            int processedLength = -1;
            int i = 0;

            while (i < content.Length)
            {
                // Skip comments
                if (i + 1 < content.Length && content[i] == '/' && content[i + 1] == '/')
                { do { i++; } while (i < content.Length && content[i] != '\n'); }

                if (ReadingValue && content[i] == '#')
                {
                    // Check if '#' is the first char
                    bool FistChar = true;
                    int j = processedLength;
                    while (j > 0 && Processed[j - 1] != '\r' && Processed[j - 1] != '\n')
                    {
                        if (Processed[j - 1] == ' ' || Processed[j - 1] == '\t')
                        {
                            --j;
                            continue;
                        }
                        FistChar = false; break;
                    }

                    // Not the first character, treat as normal character..
                    if (!FistChar)
                    {
                        Processed[processedLength++] = content[i++];
                        continue;
                    }

                    // Skip whitespaces
                    processedLength = j;
                    while (processedLength > 0 &&
                        (Processed[processedLength - 1] == '\r' || Processed[processedLength - 1] == '\n' ||
                        Processed[processedLength - 1] == ' ' || Processed[processedLength - 1] == '\t'))
                        --processedLength;

                    // Add new parameter
                    AddParam(new string(Processed,0,processedLength));
                    processedLength = 0;
                    ReadingValue = false;
                }

                if (!ReadingValue && content[i] == '#')
                {
                    AddValue();
                    ReadingValue = true;
                }

                if (!ReadingValue)
                {
                    if (unescape && content[i] == '\\')
                    {
                        i += 2;
                    }
                    else
                    {
                        i++;
                    }
                    continue;
                }

                if (processedLength != -1 && (content[i] == ':' || content[i] == ';'))
                    AddParam(new string(Processed,0,processedLength));

                if (content[i] == '#' || content[i] == ':')
                {
                    ++i;
                    processedLength = 0;
                    continue;
                }

                if (content[i] == ';')
                {
                    ReadingValue = false;
                    ++i;
                    continue;
                }

                if (unescape && i < content.Length && content[i] == '\\')
                    i++;

                if (i < content.Length)
                {
                    Processed[processedLength++] = content[i++];
                }
            }
            if (ReadingValue)
                AddParam(new string(Processed, 0, processedLength));
        }

        // Function derives from cpp (*char buff,int len)
        private void AddParam(string value)
        {
            values[values.Count - 1].Parameters.Add(value.Trim());
        }

        private void AddValue()
        {
            values.Add(new Value());
            values[values.Count - 1].Parameters.Capacity = 25;
        }

        public string GetParam(int val, int param)
        {
            if (val >= GetNumValues() || param > GetNumParams(val))
                return string.Empty;
            else return values[val].Parameters[param];
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < values.Count-1; i++)
            {
                for (int j = 0; j < values[i].Parameters.Count; j++)
                {
                    sb.Append('[').Append(values[i].Parameters[j]).Append(']');
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}