using System.Collections.Generic;

namespace SwipeSwipeMania
{
    public class SMStepfileReader
    {
        readonly Pattern[] patterns =
        {
            new Pattern("1000", ArrowDirection.left),
            new Pattern("0100", ArrowDirection.down),
            new Pattern("0010", ArrowDirection.up),
            new Pattern("0001", ArrowDirection.right),

            new Pattern("1100", ArrowDirection.downleft),
            new Pattern("0110", ArrowDirection.vertical),
            new Pattern("0011", ArrowDirection.upright),
            new Pattern("1001", ArrowDirection.horizontal),

            new Pattern("1010", ArrowDirection.upleft),
            new Pattern("0101", ArrowDirection.downright)
        };
        
        // For sorting
        readonly string[] defaultNames =
        {
            "Beginner",
            "Easy",
            "Medium",
            "Hard",
            "Expert"
        };

        public Song GenerateFromString(string fileContent)
        {
            MsdFile msd = new MsdFile();
            msd.ReadFromString(fileContent, true);

            int valueCount = msd.GetNumValues();

            // All variables needed for Song struct
            string title = "Undefined";
            float bpm = 0f;
            float offset = 0f;
            string artist = "Undefined";
            bool selectable = false;
            List<StepData> NoteDatas = new List<StepData>();

            // Lazy parsing
            for (int i = 0; i < valueCount; i++)
            {
                if (msd.GetParam(i, 0) == "TITLE")
                    title = msd.GetParam(i, 1);
                if (msd.GetParam(i, 0) == "OFFSET")
                    offset = float.Parse(msd.GetParam(i, 1));
                if (msd.GetParam(i, 0) == "BPMS")
                    bpm = float.Parse(msd.GetParam(i, 1).Split(',')[0].Split('=')[1]);
                if (msd.GetParam(i, 0) == "ARTIST")
                    artist = msd.GetParam(i, 1);
                if (msd.GetParam(i, 0) == "NOTES")
                    NoteDatas.Add(HandleNoteData(msd.GetValue(i)));
                if (msd.GetParam(0,0) == "SELECTABLE")
                {
                    if (msd.GetParam(0, 1) == "YES" ||
                        msd.GetParam(0, 1) == "TRUE" || 
                        msd.GetParam(0, 1) == "1")
                        selectable = true;
                }
            }

            SortByDifficulty(ref NoteDatas);

            return new Song(title, artist, bpm, offset, NoteDatas.ToArray(), selectable);
        }

        private void SortByDifficulty(ref List<StepData> listToSort)
        {
            List<StepData> sortedList = new List<StepData>();
            for (int i = 0; i < defaultNames.Length; i++)
            {
                for (int j = 0; j < listToSort.Count; j++)
                {
                    if (listToSort[j].difficulty == defaultNames[i])
                    {
                        sortedList.Add(listToSort[j]);
                        listToSort.Remove(listToSort[j]);
                        break;
                    }
                }
            }

            while (listToSort.Count > 0)
            {
                sortedList.Add(listToSort[0]);
                listToSort.Remove(listToSort[0]);
            }

            listToSort = sortedList;
        }

        private StepData HandleNoteData(Value NoteData)
        {
            StepData noteData;
            noteData.mode = NoteData.Parameters[1];
            noteData.title = NoteData.Parameters[2];
            noteData.difficulty = NoteData.Parameters[3];
            noteData.noteList = HandleNotes(NoteData.Parameters[6].Replace("\n","").Replace("\r",""));
            return noteData;
        }

        private ArrowInitialData[] HandleNotes(string content)
        {
            int measure = 0;
            List<ArrowInitialData> notes = new List<ArrowInitialData>();
            List<string> buffer = new List<string>();
            buffer.Clear();

            for (int i = 4; i < content.Length; i += 4)
            {
                string sub = "" + content[i - 4] + // X### RIGHT
                                  content[i - 3] + // #X## UP
                                  content[i - 2] + // ##X# DOWN
                                  content[i - 1];  // ###X LEFT
                
                // Add measurecontent in buffer
                buffer.Add(sub);

                // Did we end at a measure devisor?
                if (content[i] == ',' || content[i] == ';')
                {
                    // For every element in the buffer
                    for (int j = 0; j < buffer.Count; j++)
                    {
                        // initialize direction at none
                        ArrowDirection direction = ArrowDirection.none;

                        // Compare to every possible combination
                        // Take direction from the combination if
                        // there is a match.
                        for (int k = 0; k < patterns.Length; k++)
                        {
                            if (buffer[j] == patterns[k].pattern)
                            {
                                direction = patterns[k].direction;
                                break;
                            }
                        }

                        // If there wasn't a match, continue
                        if (direction == ArrowDirection.none)
                            continue;

                        // Add notes to our list
                        notes.Add(new ArrowInitialData(measure + (1f / buffer.Count) * j, direction));
                    }
                    buffer.Clear();

                    // Next measure
                    measure++;

                    // Skip escape character
                    i++;

                    if (content[i] == ';')
                        break;
                }
            }
            return notes.ToArray();
        }

        private struct Pattern
        {
            public string pattern;
            public ArrowDirection direction;

            public Pattern(string pattern, ArrowDirection direction)
            {
                this.pattern = pattern;
                this.direction = direction;
            }
        }
    }
}