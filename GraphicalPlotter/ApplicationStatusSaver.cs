using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GraphicalPlotter
{
    public class ApplicationStatusSaveDataHandler
    {

        public ApplicationStatusSaveDataHandler() 
        {

        }

        public void CreateApplicationSaveData(AxisData xAxis, AxisGridData xGrid, AxisData yAxis, AxisGridData yGrid, List<GraphicalFunctionDisplayNameForSerialization> functionList )
        {
            AxisSaveData xAxisSaveData = new AxisSaveData(xAxis, xGrid, "xAxis");
            AxisSaveData yAxisSaveData = new AxisSaveData(yAxis, yGrid, "yAxis");

            // we need the 
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            //i want to have a save transfer of data, just in case the application is suddenly closed while saving.
            string newFilePath = Path.Combine(basePath, "newBackupData.dat");


            XmlSerializer axisSerializer = new XmlSerializer(typeof(AxisSaveData));

            using (FileStream fileStream = new FileStream(newFilePath, FileMode.Create))
            {
                // first we allways serialize the two axis informations, we will keep this order so that when we have the same order for the Deserialization

                axisSerializer.Serialize(fileStream, xAxisSaveData);
                axisSerializer.Serialize(fileStream, yAxisSaveData);

                // now we serialize the list that was already given to use with the right class type

                XmlSerializer functionSerializer = new XmlSerializer(typeof(List<GraphicalFunctionDisplayNameForSerialization>));
                functionSerializer.Serialize(fileStream, functionList);

            }

            //if an old BackupFile exits we will delete it , else we will only rename the file that was just created to the right name.
            string oldbackupPath = Path.Combine(Environment.CurrentDirectory, "BackupData.dat");
            if (File.Exists(oldbackupPath))
            {
                File.Delete(oldbackupPath);
            }
            //renameing the file
            File.Move(newFilePath, oldbackupPath);



        }

        public bool TryToExtractBackupDataForApplication(out AxisData xAxisData,out AxisData yAxisData, out AxisGridData xGridData, AxisGridData yGridData,out List<GraphicalFunctionDisplayNameForSerialization> functions)
            
        {
            

           //extract the data with a xmlserilalizer like before and set the out values , if anything goes wrong return false, and just use the default values that i have set.

            //TRY CATCH!!!! 

        
        }







    }
}
