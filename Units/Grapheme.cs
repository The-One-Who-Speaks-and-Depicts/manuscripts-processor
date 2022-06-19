using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CorpusDraftCSharp
{
    [Serializable]
    public class Grapheme : ICorpusUnit, IComparable<Grapheme>
    {
        [JsonProperty]
        public string filePath { get; set; }
        [JsonProperty]
        public List<Dictionary<string, List<Value>>> tagging { get; set; }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string text { get; set; }


        [JsonConstructor]
        public Grapheme(string _filePath,  List<Dictionary<string, List<Value>>> _fields, string _graphemeID, string _grapheme)
        {
            this.filePath = _filePath;
            this.tagging = _fields;
            this.Id = _graphemeID;
            this.text = _grapheme;
        }

        public Grapheme(Token realization, string _graphemeID, string _grapheme)
        {
            this.filePath = realization.filePath;
            this.Id = realization.Id + "|" + _graphemeID;
            this.text = _grapheme;
        }

        public Grapheme(string _filePath, string _graphemeID, string _grapheme)
        {
            this.filePath = _filePath;
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
                return "<span title=\"" + fieldsInRawText.Invoke(tagging) + "\" data-content=\"" + fieldsInHTML.Invoke(tagging) + "\" class=\"grapheme\" id=\"" + Id + "\">" + text + "</span>";
            }
            catch
            {
                return "<span title= \"\" data-content=\"\" class=\"grapheme\" id=\"" + Id + "\">" + text + "</span>";
            }
        }
        public int CompareTo(Grapheme other)
        {
            return MyExtensions.CompareIds(Id, other.Id);
        }
    }
}
