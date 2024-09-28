using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingFormat
{
    public class FileInput
    {
        public int GetAnalyst() => _analyst;
        public int GetSystem() => _system;
        public int GetConfidence() => _confidence;
        public int GetPresentation() => _presentation;

        public FileInput()
        {
            FileInputMethod();
        }

        private void FileInputMethod()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(directoryPath, "input.txt");
            int[] analystParams = new int[10];
            int[] systemParams = new int[10];
            int[] presentationParams = new int[10];
            int[] confidenceParam = new int[5];

            using (StreamReader readFile = new StreamReader(filePath))
            {
                for (int i = 0; i < analystParams.Length; i++)
                {
                    analystParams[i] = Convert.ToInt16(readFile.ReadLine());
                }
                for (int j = 0; j < systemParams.Length; j++)
                {
                    systemParams[j] = Convert.ToInt16(readFile.ReadLine());
                }
                for (int p = 0; p < presentationParams.Length; p++)
                {
                    presentationParams[p] = Convert.ToInt16(readFile.ReadLine());
                }
                for (int c = 0; c < confidenceParam.Length; c++)
                {
                    confidenceParam[c] = Convert.ToInt16(readFile.ReadLine());
                }
            }
         }

        private int _analyst;
        private int _system;
        private int _confidence;
        private int _presentation;
    }
}