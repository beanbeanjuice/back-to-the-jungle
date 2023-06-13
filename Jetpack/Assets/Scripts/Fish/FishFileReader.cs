using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;
using UnityEditor;
using UnityEngine;
using CompressionLevel = OfficeOpenXml.CompressionLevel;

namespace Fish
{
    /// <summary>
    /// A class used to read a excel file and convert it into fish patterns.
    /// <para></para>
    /// <a href="https://www.epplussoftware.com/">EPPlus Excel Documentation</a>
    /// <remarks>Coded by William.</remarks>
    /// </summary>
    public class FishFileReader
    {
        private const string FILE_NAME = "fish_patterns";
        private const string RED = "#FFFF0000";
        private const string BLACK = "#FF0D0D0D";

        private int _sheets;
        private FishPattern[] _patterns;
        private bool _isInitialized;

        /// <summary>
        /// Create a new fish file reader.
        /// </summary>
        /// <param name="sheets">The number of pattern sheets in the excel file.</param>
        //public FishFileReader(int sheets)
        //{
        //    this._sheets = sheets;
        //    this._patterns = new FishPattern[sheets];
        //}

        /// <summary>
        /// Get the fish patterns stored in memory.
        /// </summary>
        /// <returns>A primitive array of fish patterns.</returns>
        /// <exception cref="NullReferenceException">Thrown if the fish patterns have not been initialized in memory.</exception>
        public FishPattern[] GetPatterns()
        {
            if (!this._isInitialized) throw new NullReferenceException("Fish patterns have not been initialized.");

            return this._patterns;
        }

        /// <summary>
        /// Initializes the patterns in memory. Required on startup.
        /// </summary>
        public void Initialize(CustomTextAsset file)
        {
            //CustomTextAsset file = Resources.Load<CustomTextAsset>(FILE_NAME);

            if (null == file) throw new NullReferenceException("Fish patterns file is missing...");

            //BinaryFormatter formatter = new BinaryFormatter();
            //Stream fileStream = new MemoryStream(file.bytes);

            //formatter.Deserialize(fileStream);

            //string filepath = Path.Join(Application.streamingAssetsPath, FILE_NAME);
            //UnityWebRequest request = UnityWebRequest.Get(filepath);
            //request.SendWebRequest();

            //while (!request.isDone) { }
            //byte[] file = request.downloadHandler.data;

            // Set license to non-commercial. Needed for more workbooks, plus this is academic use.
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Open the excel file. Located in StreamingAssets folder.
            using ExcelPackage package = new ExcelPackage();

            Stream stream = new MemoryStream(file.bytes);

            package.Compression = CompressionLevel.None;

            package.LoadAsync(stream);

            //while (package.Workbook.Worksheets.Count < this._sheets)
            //{
            //    Debug.Log($"Sheets: {package.Workbook.Worksheets.Count}");
            //}

            // Go through every worksheet in the workbook.
            //Debug.Log($"Size 7: {file.bytes.Length}");

            this._sheets = package.Workbook.Worksheets.Count;
            this._patterns = new FishPattern[this._sheets];

            try
            {
                for (int i = 0; i < this._sheets; i++)
                {
                    Debug.Log($"INDEX: {i}");
                    this._patterns[i] = ReadSheet(package, i);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.Log($"HERE!: {e.Message}");
            }

            // Close the excel workbook when completed.
            package.Dispose();
            this._isInitialized = true;

            FishPatternsAsset fishPatternsAsset = FishPatternsAsset.CreatePatterns(this._patterns);
            AssetDatabase.CreateAsset(fishPatternsAsset, "Assets/Resources/fish_patterns_asset.asset");

            Debug.Log(AssetDatabase.GetAssetPath(fishPatternsAsset));
        }

        private FishPattern ReadSheet(ExcelPackage package, int sheetNumber)
        {
            Debug.Log("WOW 1");
            ExcelWorksheet sheet = package.Workbook.Worksheets[sheetNumber];

            Debug.Log("WOW 2");
            string initialPosition = ReadSheetValue(sheet, 0, 0);
            string finalPosition = ReadSheetValue(sheet, 1, 0);

            int startX = 0;
            int startY = 0;
            int endX = 0;
            int endY = 0;

            /*
             * Use reference variables to set both
             * the X and Y positions at the same time.
             */
            ConvertPosition(initialPosition, ref startX, ref startY);
            ConvertPosition(finalPosition, ref endX, ref endY);

            int occupiedCellsXLength = Math.Abs(endX - startX) + 1;
            int occupiedCellsYLength = Math.Abs(endY - startY) + 1;

            bool[,] occupiedCells = new bool[occupiedCellsXLength, occupiedCellsYLength];

            int zeroX = 0;
            int zeroY = 0;
            int count = 0;

            int x0 = 0;  // X position of occupied cells.
            for (int x = startX; x <= endX; x++, x0++)
            {
                int y0 = 0;  // Y position of occupied cells.
                for (int y = startY; y >= endY; y--, y0++)
                {
                    // Hex color of current cell.
                    string hexColor = GetCellHex(sheet, x, y);

                    occupiedCells[x0, y0] = false;  // Initial set.

                    if (hexColor.Equals(BLACK) || hexColor.Equals(RED))
                    {
                        occupiedCells[x0, y0] = true;
                        count++;
                    }

                    // If the cell color is red, then it is the relative (0,0) cell.
                    if (!hexColor.Equals(RED)) continue;

                    zeroX = x0;
                    zeroY = y0;
                }
            }

            return ConvertToPattern(occupiedCells, occupiedCellsXLength, occupiedCellsYLength, zeroX, zeroY, count);
        }

        private FishPattern ConvertToPattern(bool[,] occupiedCells, int xLength, int yLength, int zeroX, int zeroY, int count)
        {
            Vector2[] offsets = new Vector2[count];
            int i = 0;

            // Set (0,0) fish. Relative coordinates.
            offsets[i++] = new Vector2(0, 0);

            // Reset the (0,0) fish so that it is not counted twice.
            occupiedCells[zeroX, zeroY] = false;

            // Set other fish.
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if (!occupiedCells[x, y]) continue;

                    /*
                     * Since we are working with relative coordinates, we need
                     * to "move" the other values relative toward the RED box (aka 0,0).
                     */
                    int relativeX = x - zeroX;
                    int relativeY = y - zeroY;

                    offsets[i++] = new Vector2(relativeX, relativeY);
                }
            }

            FishPattern pattern = new FishPattern();
            pattern.SetOffsets(offsets);
            return pattern;
        }

        private void ConvertPosition(string position, ref int x, ref int y)
        {
            x = position[0] - 'A' + 1;  // +1 is needed to avoid errors.
            y = position[1] - '0';
        }

        private string ReadSheetValue(ExcelWorksheet sheet, int x, int y)
        {
            return (string)sheet.Cells[++y, ++x].Value;
        }

        private string GetCellHex(ExcelWorksheet sheet, int x, int y)
        {
            return sheet.Cells[y, x].Style.Fill.BackgroundColor.LookupColor();
        }
    }
}
