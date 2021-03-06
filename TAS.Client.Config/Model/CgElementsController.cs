﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using TAS.Common.Interfaces;

namespace TAS.Client.Config.Model
{
    public class CgElementsController
    {       
        [XmlAttribute]
        public string EngineName { get; set; }
        [XmlArray]
        [XmlArrayItem("Command")]
        public List<string> Startup { get; set; }        
        [XmlArray]
        [XmlArrayItem("Crawl")]
        public List<CgElement> Crawls { get; set; }
        [XmlArray]
        [XmlArrayItem("Logo")]
        public List<CgElement> Logos { get; set; }
        [XmlArray]
        [XmlArrayItem("Parental")]
        public List<CgElement> Parentals { get; set; }
        [XmlArray]
        [XmlArrayItem("Aux")]
        public List<CgElement> Auxes { get; set; }


        public CgElementsController()
        {

        }
    }
}
