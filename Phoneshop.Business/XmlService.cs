using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Phoneshop.Business
{
    public class XmlService : IXmlService
    {
        private readonly IBrandService _brandService;

        public XmlService(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public List<Phone> Read(TextReader xml)
        {
            if (xml is null)
                throw new ArgumentNullException(nameof(xml));

            var result = new List<Phone>();

            using var reader = XmlReader.Create(xml);
            Phone p = null;

            while (reader.Read())
            {
                if (!reader.IsStartElement() && reader.Name == "Phone")
                    result.Add(p);

                if (reader.IsStartElement() && reader.Name == "Phone")
                    p = new Phone();

                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "Brand":
                            if (reader.Read())
                            {
                                if (p != null) p.Brand = _brandService.GetOrCreate(reader.Value);
                            }

                            break;

                        case "Type":
                            if (reader.Read())
                                if (p != null)
                                    p.Type = reader.Value;
                            break;

                        case "Price":
                            if (reader.Read())
                                if (p != null)
                                    p.Price = Convert.ToDouble(reader.Value);
                            break;

                        case "Description":
                            if (reader.Read())
                                if (p != null)
                                    p.Description = reader.Value;
                            break;

                        case "Stock":
                            if (reader.Read())
                                if (p != null)
                                    p.Stock = Convert.ToInt32(reader.Value);
                            break;
                    }
                }
            }

            return result;
        }
    }
}