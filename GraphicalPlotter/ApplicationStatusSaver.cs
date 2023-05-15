

namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Media;
    using System.Xml.Serialization;
    public class ApplicationStatusSaveDataHandler
    {
        public ApplicationStatusSaveDataHandler()
        {
        }

        public void CreateApplicationSaveData(AxisData xAxis, AxisGridData xGrid, AxisData yAxis, AxisGridData yGrid, List<GraphicalFunctionDisplayNameForSerialization> functionList, bool hasUserchangedYAxisValues)
        {
            AxisSaveData xAxisSaveData = new AxisSaveData(xAxis, xGrid);
            AxisSaveData yAxisSaveData = new AxisSaveData(yAxis, yGrid);

            //// i can get the basedirectory like this, but i also found : Environment.CurrentDirectory , but i think this is better
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            //// i want to have a save transfer of data, just in case the application is suddenly closed while saving.
            string newFilePath = Path.Combine(basePath, "newBackupData.dat");

            XmlSerializer plotterSerializer = new XmlSerializer(typeof(PlotterFullSaveData));

            using (FileStream fileStream = new FileStream(newFilePath, FileMode.Create))
            {
                //// first we allways serialize the two axis informations, we will keep this order so that when we have the same order for the Deserialization
                PlotterFullSaveData plotterSaveData = new PlotterFullSaveData(xAxisSaveData, yAxisSaveData, functionList, hasUserchangedYAxisValues);
                plotterSerializer.Serialize(fileStream, plotterSaveData);
            }

            //// if an old BackupFile exits we will delete it , else we will only rename the file that was just created to the right name.
            string oldbackupPath = Path.Combine(Environment.CurrentDirectory, "BackupData.dat");

            if (File.Exists(oldbackupPath))
            {
                File.Delete(oldbackupPath);
            }
            //// renameing the file
            File.Move(newFilePath, oldbackupPath);
        }

        public bool TryToExtractBackupDataForApplication(
            out AxisData xAxisData,
            out AxisData yAxisData,
            out AxisGridData xGridData,
            out AxisGridData yGridData,
            out List<GraphicalFunctionDisplayNameForSerialization> functions,
            out bool hasUserChangedYAxisValues)

        {
            xAxisData = new AxisData(-10, 10, Colors.Azure, true);
            yAxisData = new AxisData(-10, 10, Colors.Azure, true);
            xGridData = new AxisGridData(1, Colors.LightSlateGray, true);
            yGridData = new AxisGridData(1, Colors.LightSlateGray, true);
            functions = new List<GraphicalFunctionDisplayNameForSerialization>();
            hasUserChangedYAxisValues = false;

            try
            {
                string backupPath = Path.Combine(Environment.CurrentDirectory, "BackupData.dat");

                if (File.Exists(backupPath))
                {
                    XmlSerializer PlotterDeserializer = new XmlSerializer(typeof(PlotterFullSaveData));

                    using (FileStream fileStream = new FileStream(backupPath, FileMode.Open))
                    {
                       

                        PlotterFullSaveData fullSaveData = (PlotterFullSaveData)PlotterDeserializer.Deserialize(fileStream);

                        xAxisData = new AxisData(fullSaveData.XAxisSaveData.AxisMin, fullSaveData.XAxisSaveData.AxisMax, fullSaveData.XAxisSaveData.AxisLineColor, fullSaveData.XAxisSaveData.AxisLineVisibility);
                        xGridData = new AxisGridData(fullSaveData.XAxisSaveData.GridIntervall, fullSaveData.XAxisSaveData.GridLineColor, fullSaveData.XAxisSaveData.GridVisibility);

                        yAxisData = new AxisData(fullSaveData.YAxisSaveData.AxisMin, fullSaveData.YAxisSaveData.AxisMax, fullSaveData.YAxisSaveData.AxisLineColor, fullSaveData.YAxisSaveData.AxisLineVisibility);
                        yGridData = new AxisGridData(fullSaveData.YAxisSaveData.GridIntervall, fullSaveData.YAxisSaveData.GridLineColor, fullSaveData.YAxisSaveData.GridVisibility);

                        
                        functions = fullSaveData.SerializationFunctionList;
                        hasUserChangedYAxisValues = fullSaveData.HasUserChangedYAxis;
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException) 
            {
                return false;
            }
            catch (Exception)
            {
               

                return false;
            }
        }
    }
}