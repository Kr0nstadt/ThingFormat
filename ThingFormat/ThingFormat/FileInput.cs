using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingFormat.Properties;

namespace ThingFormat
{
    public class FileInput
    {
        public Analyst Analyst => _analyst;
        public Properties.System System=> _system;
        public Confidence Confidence => _confidence;
        public Presentation Presentation => _presentation;

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
                    analystParams[i] = Convert.ToInt32(readFile.ReadLine());
                   
                }
                for (int j = 0; j < systemParams.Length; j++)
                {
                    systemParams[j] = Convert.ToInt32(readFile.ReadLine());
                }
                for (int p = 0; p < presentationParams.Length; p++)
                {
                    presentationParams[p] = Convert.ToInt32(readFile.ReadLine());
                }
                for (int c = 0; c < confidenceParam.Length; c++)
                {
                    confidenceParam[c] = Convert.ToInt32(readFile.ReadLine());
                }
                int analystSum = analystParams.Sum();
                int systemSum = systemParams.Sum();
                int presentationSum = presentationParams.Sum();
                int confidenceSum = confidenceParam.Sum();

                _analyst = new Analyst(analystSum);
                _system = new Properties.System(systemSum); 
                _confidence = new Confidence(confidenceSum); 
                _presentation = new Presentation(presentationSum); 
            }
         }

        private Analyst _analyst;
        private Properties.System _system;
        private Confidence _confidence;
        private Presentation _presentation;
    }
}