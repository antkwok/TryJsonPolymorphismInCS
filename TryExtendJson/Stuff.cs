using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace TryExtendJson
{
    
    public class Elements : List<Element>
    {
        
    }
    
    public class Element
    {
        public string Name { get; set; } = "";
        public double Top { get; set; } = 0;
        public double Left { get; set; } = 0;
        public double Width { get; set; } = 50;
        public double Height { get; set; } = 10;

    }

    public class TextBox : Element
    {
        public string FontSize { get; set; } = "12pt";
        public string Text { get; set; } = "";
    }

    public class SignaturePad : Element
    {
        public string SignatureLink { get; set; } = "";
    }

    public class CheckBox : Element
    {
        public bool Checked { get; set; } = false;
    }
}