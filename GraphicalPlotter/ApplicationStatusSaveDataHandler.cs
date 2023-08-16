//-----------------------------------------------------------------------
// <copyright file="ApplicationStatusSaveDataHandler.cs" company="FHWN">
//     Copyright (c) Monkey with a Typewriter GMBH. All rights reserved.
// </copyright>
// <author>Jens Hanssen</author>
// <summary>
// This class handles all the necessary steps to serialize and save the current application status.
// </summary>
//-----------------------------------------------------------------------
namespace GraphicalPlotter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Xml.Serialization;

    /// <summary>
    /// The class used for saving the current status of the application as an xml file.
    /// </summary>
    public class ApplicationStatusSaveDataHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationStatusSaveDataHandler" /> class.
        /// </summary>
        public ApplicationStatusSaveDataHandler()
        {
        }

        ////TODO it would make sense to paramterise the filename that is generated for the save data file, and also the name for the old save data file.
        ////TODO encrypt the file in a format of your choosing.

        /// <summary>
        /// This method creates a new save data file inside the current running directory of the application. 
        /// While creation the save data still has a different name and only after the serialization is over the old save file will be deleted.
        /// </summary>
        /// <param name="xAxis"> The AxisData for the x-axis of application that should be saved.</param>
        /// <param name="xGrid"> The AxisData for the y-axis of application that should be saved.</param>
        /// <param name="yAxis"> The AxisGridData for the x-axis of application that should be saved.</param>
        /// <param name="yGrid"> The AxisGridData for the y-axis of application that should be saved.</param>
        /// <param name="functionList"> The list of functions for the application that should be saved.</param>
        /// <param name="hasUserchangedYAxisValues"> The boolean indicating whether or not the user ever changed an attribute in the y-axis.</param>
        /// <exception cref="ArgumentNullException"> Is raised if ..... xAxis is null
        ///                                                       ..... yAxis is null
        ///                                                       ..... yGrid is null
        ///                                                       ..... xGrid is null
        ///                                                       ..... functionList is null.
        /// </exception>
        public void CreateApplicationSaveData(AxisData xAxis, AxisGridData xGrid, AxisData yAxis, AxisGridData yGrid, List<GraphicalFunctionForSerialization> functionList, bool hasUserchangedYAxisValues)
        {
            if (xAxis == null)
            {
                throw new ArgumentNullException($"{nameof(xAxis)} can not be null!");
            }

            if (xGrid == null)
            {
                throw new ArgumentNullException($"{nameof(xGrid)} cannot be null!");
            }

            if (yAxis == null)
            {
                throw new ArgumentNullException($"{nameof(yAxis)} cannot be null!");
            }

            if (yGrid == null)
            {
                throw new ArgumentNullException($"{nameof(yGrid)} cannot be null!");
            }

            if (functionList == null)
            {
                throw new ArgumentNullException($"{nameof(functionList)} cannot be null!");
            }

            //// The save data is currently just a xml file , but if you want to decrypt it before then you just need to add a encryption method before the serialization.
            AxisSaveData xAxisSaveData = new AxisSaveData(xAxis, xGrid);
            AxisSaveData yAxisSaveData = new AxisSaveData(yAxis, yGrid);

            //// i can get the basedirectory like this, but i also found : Environment.CurrentDirectory , but i think this is better
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            //// i want to have a save transfer of data, just in case the application is suddenly closed while saving.
            string newFilePath = Path.Combine(basePath, "newBackupData.dat");

            XmlSerializer plotterSerializer = new XmlSerializer(typeof(PlotterFullSaveData));
            try
            {
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
            catch (IOException)
            {

                MessageBox.Show("Reading the File failed, probably becouse it currently is in use! Try with a diffrent File name and/or location! No save was created!");
            }
            catch (UnauthorizedAccessException)
            {

                MessageBox.Show("Overwritting the file failed because it is read only! Try with a diffrent File name and/or location! No save was created!");
            }



        }

        //// TODO the setting to default values should happen wherever tis method is called not inside the method. If it directly sets the values to default values the name is misleading and two functions are combined in one

        /// <summary>
        /// This method tries to locate a file in the current running directory, and read the application status from it. 
        /// If the file does not exits, default values are set for the attributes of the Graph Plotter.
        /// </summary>
        /// <param name="xAxisData"> The AxisData for the x-axis of application was read from the file or set to a default value.</param>
        /// <param name="yAxisData"> The AxisData for the y-axis of application was read from the file or set to a default value..</param>
        /// <param name="xGridData"> The AxisGridData for the x-axis of application that was read from the file or set to a default value.</param>
        /// <param name="yGridData"> The AxisGridData for the y-axis of application was read from the file or set to a default value.</param>
        /// <param name="functions"> The list of functions for the application that was read from the file or set to a default value.</param>
        /// <param name="hasUserChangedYAxisValues"> The boolean indicating whether or not the user ever changed an attribute in the y-axis that was read from the file or set to a default value.</param>
        /// <returns> Returns a boolean value indicating whether or not it succeeded in reading the save data. </returns>
        public bool TryToExtractBackupDataForApplication(
            out AxisData xAxisData,
            out AxisData yAxisData,
            out AxisGridData xGridData,
            out AxisGridData yGridData,
            out List<GraphicalFunctionForSerialization> functions,
            out bool hasUserChangedYAxisValues)
        {
            xAxisData = new AxisData(-10, 10, Colors.Azure, true);
            yAxisData = new AxisData(-10, 10, Colors.Azure, true);
            xGridData = new AxisGridData(1, Colors.LightSlateGray, true);
            yGridData = new AxisGridData(1, Colors.LightSlateGray, true);
            functions = new List<GraphicalFunctionForSerialization>();
            hasUserChangedYAxisValues = false;

            try
            {
                string backupPath = Path.Combine(Environment.CurrentDirectory, "BackupData.dat");

                if (File.Exists(backupPath))
                {
                    XmlSerializer plotterDeserializer = new XmlSerializer(typeof(PlotterFullSaveData));

                    using (FileStream fileStream = new FileStream(backupPath, FileMode.Open))
                    {
                        PlotterFullSaveData fullSaveData = (PlotterFullSaveData)plotterDeserializer.Deserialize(fileStream);

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