using CoveoApiVbg.Helper;
using CoveoApiVbg.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Data
{
    public class DBcontextInMemory : IDBcontext
    {
        private const string fileToLoadForCities = @"cities_can_usa.xlsx";
        private readonly List<Ville> villes;



        public DBcontextInMemory()
        {
            villes = new List<Ville>();
            if (villes.Count <= 0)
            {
                //suggestions = ReadFromExcel<List<Suggestion>>(@"G:\Source\CoveoTest\data\cities_canada-usa.tsv");
                FillCitiesInMemoryFromExcelFile();
               // suggestions.Add(new Suggestion { Id = 1, Latitude = 0, Longitude = 0, Name = "London", Score = 1 });
                //suggestions.Add(new Suggestion { Id = 2, Latitude = 0, Longitude = 0, Name = "Quebec", Score = 0 });
            }
        }

        public async Task<List<Ville>> Get(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ville>> GetAll()
        {
            return villes;
        }

        public void FillCitiesInMemoryFromExcelFile()
        {

            FileInfo file = new FileInfo(fileToLoadForCities);
            if (file.Exists)
            {

                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {


                    ExcelWorksheet firstWorksheet = excelPackage.Workbook.Worksheets.First();
                    int totalRows = firstWorksheet.Dimension.End.Row;
                    int totalCols = firstWorksheet.Dimension.End.Column;

                    for(int i = 2; i <= totalRows; ++i)
                    {
                        Ville villePresente = new Ville();
                        villePresente.Id = firstWorksheet.Cells[i, 1].Value == null ?  0 :  firstWorksheet.Cells[i, 1].Value.ToString().ParseInt();
                        villePresente.Name = firstWorksheet.Cells[i, 2].Value == null ? string.Empty : firstWorksheet.Cells[i, 2].Value.ToString();
                        villePresente.Ascii = firstWorksheet.Cells[i, 3].Value == null ? string.Empty : firstWorksheet.Cells[i, 3].Value.ToString();
                        villePresente.Latitude = firstWorksheet.Cells[i, 5].Value == null ? float.MinValue : (float)firstWorksheet.Cells[i, 5].Value.ToString().ParseNullableFloat();
                        villePresente.Longitude = firstWorksheet.Cells[i, 6].Value == null ? float.MinValue : (float)firstWorksheet.Cells[i, 6].Value.ToString().ParseNullableFloat();
                        villePresente.Country = firstWorksheet.Cells[i, 9].Value == null ? string.Empty : firstWorksheet.Cells[i, 9].Value.ToString();
                        villePresente.Tz = firstWorksheet.Cells[i, 18].Value == null ? string.Empty : firstWorksheet.Cells[i, 18].Value.ToString();

                        villes.Add(villePresente);
                    }
                  

                    //Get the content from cells A1 and B1 as string, in two different notations
                    string valA1 = firstWorksheet.Cells["A1"].Value.ToString();
                    string valB1 = firstWorksheet.Cells[2, 1].Value.ToString();

                    //Save your file
                    excelPackage.Save();
                }
            }

        }

    }
}
