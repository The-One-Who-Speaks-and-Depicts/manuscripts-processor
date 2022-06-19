using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorpusDraftCSharp
{
    [Serializable]
    public class Grapheme : ICorpusUnit
    {
        [JsonProperty]
        public string documentID { get; set; }
        [JsonProperty]
        public string filePath { get; set; }
        [JsonProperty]
        public string textID { get; set; }
        [JsonProperty]
        public string clauseID { get; set; }
        [JsonProperty]
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public string realizationID { get; set; }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string text { get; set; }


        [JsonConstructor]
        public Grapheme(string _documentID, string _filePath, string _textID, string _clauseID, List<Dictionary<string, List<Value>>> _fields, string _realizationID, string _graphemeID, string _grapheme)
        {
            this.documentID = _documentID;
            this.filePath = _filePath;
            this.textID = _textID;
            this.clauseID = _clauseID;
            this.tagging = _fields;
            this.realizationID = _realizationID;
            this.Id = _graphemeID;
            this.text = _grapheme;
        }

        public Grapheme(Token realization, string _graphemeID, string _grapheme)
        {
            this.documentID = realization.documentID;
            this.filePath = realization.filePath;
            this.textID = realization.textID;
            this.clauseID = realization.clauseID;
            this.realizationID = realization.Id;
            this.Id = _graphemeID;
            this.text = _grapheme;
        }

        public Grapheme(string _documentID, string _filePath, string _textID, string _clauseID, string _realizationID, string _graphemeID, string _grapheme)
        {
            this.documentID = _documentID;
            this.filePath = _filePath;
            this.textID = _textID;
            this.clauseID = _clauseID;
            this.realizationID = _realizationID;
            this.Id = _graphemeID;
            this.text = _grapheme;
        }

        public Grapheme()
        {

        }

        public string Jsonize()
        {
            string realizationToJson = JsonConvert.SerializeObject(this, Formatting.Indented);
            return realizationToJson;
        }

        public string Output()
        {
            try
            {
                Func<List<Dictionary<string, List<Value>>>, string> fieldsInRawText = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    string result = "";
                    foreach (var optional_tagging in fields)
                    {
                        foreach (var field in optional_tagging)
                        {
                            result += field.Key;
                            result += ":";
                            for (int i = 0; i < field.Value.Count; i++)
                            {
                                result += field.Value[i].name;
                                if (i < field.Value.Count - 1)
                                {
                                    result += ",";
                                }
                            }
                            result += ";\n";
                        }
                    }
                    return result;
                };
                Func<List<Dictionary<string, List<Value>>>, string> fieldsInHTML = (List<Dictionary<string, List<Value>>> fields) =>
                {
                    return fieldsInRawText.Invoke(fields).Replace("\n", "<br />");
                };
                return "<span title=\"" + fieldsInRawText.Invoke(tagging) + "\" data-content=\"" + fieldsInHTML.Invoke(tagging) + "\" class=\"grapheme\" id=\"" + this.documentID + "|" + this.textID + "|" + this.clauseID + "|" + this.realizationID + "|" + this.Id + "\">" + text + "</span>";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"grapheme\" id=\"" + this.documentID + "|" + this.textID + "|" + this.clauseID + "|" + this.realizationID + "|" + this.Id + "\">" + text + "</span>";
            }
        }
    }
}
