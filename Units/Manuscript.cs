using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;

namespace CorpusDraftCSharp
{
    public class Manuscript : ICorpusUnit, IComparable<Manuscript>
    {


        #region objectValues
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string text { get; set; }
        [JsonProperty]
        public string filePath;
        [JsonProperty]
        public string googleDocPath;
        [JsonProperty]
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public List<Section> texts = new List<Section>();
        #endregion

        #region Constructors

        [JsonConstructor]
        public Manuscript(string _documentID, string _documentName, string _filePath, string _googleDocPath, List<Dictionary<string, List<Value>>> _documentMetaData, List<Section> _texts)
        {
            Id = _documentID;
            text = _documentName;
            filePath = _filePath;
            googleDocPath = _googleDocPath;
            tagging = _documentMetaData;
            texts = _texts;
        }

        public Manuscript(string _documentID, string _documentName, string _filePath, string _googleDocPath)
        {
            Id = _documentID;
            text = _documentName;
            filePath = _filePath;
            googleDocPath = _googleDocPath;
        }

        public Manuscript()
        {

        }

        #endregion
        #region PublicMethods
        public string Jsonize()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return json;
        }

        public string Output()
        {
            Func<string> parts = () =>
            {
                string collected = "";
                texts.Sort();
                foreach (var t in texts)
                {
                    collected += t.Output();
                }
                return collected;
            };
            try
            {
                Func<List<Dictionary<string, List<Value>>>, string> documentInRawText = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    string result = "";
                    foreach (var optional_tagging in fields)
                    {
                        foreach (var field in optional_tagging)
                        {
                            result += field.Key;
                            result += ":";
                            foreach (var fieldValue in field.Value)
                            {
                                result += fieldValue.name;
                                result += ";";
                            }
                            result += "||";
                        }
                        result += "\n";
                    }
                    return result;
                };
                Func<List<Dictionary<string, List<Value>>>, string> documentInHTML = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    return documentInRawText.Invoke(fields).Replace("\n", "<br />");
                };
                return "<span title=\"" + documentInRawText.Invoke(tagging) + "\" data-content=\"" + documentInHTML.Invoke(tagging) + "\" class=\"text\" id=\"" + this.Id + "\"> " + parts.Invoke() + "</span><br />";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"text\" id=\"" + this.Id + "\"> " + parts.Invoke() + "</span><br />";
            }
        }
        #endregion

        public int CompareTo(Manuscript other)
        {
            return MyExtensions.CompareIds(Id, other.Id);
        }



    }
}
