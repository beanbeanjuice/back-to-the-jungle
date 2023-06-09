using System;
using System.IO;
using Fish.Patterns;
using OfficeOpenXml;
using UnityEngine;

namespace Fish
{
    public class FishFileReader
    {
        private const string FILE_NAME = "Assets/Resources/fish_patterns.xlsx";
        private const string RED = "#FFFF0000";
        private const string BLACK = "#FF0D0D0D";
        private int _sheets;

        public FishPattern2 pattern;

        public FishFileReader(int sheets)
        {
            this._sheets = sheets;
        }

        public void ReadPatterns()
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(FILE_NAME)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                for (int i = 0; i < this._sheets; i++)
                {
                    ReadSheet(package, 6);  // Change to i
                }

                package.Dispose();  // Closes the workbook.
            }
        }

        private void ReadSheet(ExcelPackage package, int sheetNumber)
        {
            ExcelWorksheet sheet = package.Workbook.Worksheets[sheetNumber];

            string initialPosition = ReadSheetValue(sheet, 0, 0);
            string finalPosition = ReadSheetValue(sheet, 1, 0);

            int startX = 0;
            int startY = 0;
            int endX = 0;
            int endY = 0;

            ConvertPosition(initialPosition, ref startX, ref startY);
            ConvertPosition(finalPosition, ref endX, ref endY);

            Debug.Log($"({startX}, {startY})");  // TODO: Remove in production.
            Debug.Log($"({endX}, {endY})");

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
                    string hexColor = GetCellHex(sheet, x, y);

                    occupiedCells[x0, y0] = false;  // Initial set.

                    if (hexColor.Equals(BLACK) || hexColor.Equals(RED))
                    {
                        occupiedCells[x0, y0] = true;
                        count++;
                    }

                    if (hexColor.Equals(RED))
                    {
                        zeroX = x0;
                        zeroY = y0;
                    }
                }
            }

            this.pattern = ConvertToPattern(occupiedCells, occupiedCellsXLength, occupiedCellsYLength, zeroX, zeroY, count);

            Debug.Log($"Zero: ({zeroX}, {zeroY})");
            Debug.Log(this.pattern.GetFishCount());
        }

        private FishPattern2 ConvertToPattern(bool[,] occupiedCells, int xLength, int yLength, int zeroX, int zeroY, int count)
        {
            Vector2[] offsets = new Vector2[count];
            int i = 0;

            // Set (0,0).
            offsets[i++] = new Vector2(0, 0);
            occupiedCells[zeroX, zeroY] = false;

            // Set other fish.
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if (occupiedCells[x, y])
                    {
                        int relativeX = x - zeroX;
                        int relativeY = zeroY - y;

                        offsets[i++] = new Vector2(relativeX, relativeY);
                    }
                }
            }

            FishPattern2 pattern = new FishPattern2();
            pattern.SetOffsets(offsets);
            return pattern;
        }

        private void ConvertPosition(string position, ref int x, ref int y)
        {
            x = position[0] - 'A' + 1;
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
