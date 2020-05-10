﻿using Furny.Common;
using Furny.Models;
using Furny.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Furny.Common.Enums;

namespace Furny.Services
{
    public class ExportService : IExportService
    {
        private readonly IExcelService _excelService;
        private ExcelType _excelType;
        private string _fileName;
        private IEnumerable<List<Component>> _components;

        public ExportService(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public async Task<Tuple<MemoryStream, string>> ExportAsync(ExcelType excelType, IEnumerable<List<Component>> components)
        {
            _excelType = excelType;
            _components = components;
            _fileName = excelType.GetDescription();

            switch (_excelType)
            {
                case ExcelType.ErFa:
                    return await ErFaCreatorAsync();
                default:
                    return null;
            }
        }

        public async Task<Tuple<MemoryStream, string>> ErFaCreatorAsync()
        {
            uint row = 15;
            string path = string.Empty;

            foreach (var c in _components)
            {
                path = _excelService.UpdateCell(_fileName, "D", row, $"{c.Count}");
                _excelService.UpdateCell(_fileName, "E", row, $"{c.First().Height}");
                _excelService.UpdateCell(_fileName, "F", row, $"{c.First().Width}");
                _excelService.UpdateCell(_fileName, "G", row, $"{c.First().Name}");

                row++;
            }

            return await ToTupleAsync(path);
        }

        private async Task<Tuple<MemoryStream, string>> ToTupleAsync(string path)
        {
            var file = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(file);
            }
            file.Position = 0;

            return new Tuple<MemoryStream, string>(file, path);
        }
    }
}
